using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }
    
    public class Subject : ISubject
    {
        public int State { get; set; } = -0;


        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
        
        public void DoSomething()
        {
            Console.WriteLine("\nSubject: I'm doing something.");
            State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: something changed, publishing event " + State);
            Notify();
        }
    }

    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {            
            if (((Subject) subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if (((Subject) subject).State == 0 || ((Subject) subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event.");
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            var rnd = new Random();
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            var observerB = new ConcreteObserverB();
            
            Parallel.For(0, 5, (i, loopState) =>
            {
                int delay;
                lock (rnd)
                    delay = rnd.Next(1, 1001);
                Thread.Sleep(delay);
                Console.WriteLine("Thread : " + i);
                subject.Attach(observerA);
                subject.DoSomething();
                subject.Detach(observerB);
            });
        }
    }
}