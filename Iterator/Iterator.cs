using System;
using System.Collections.Generic;

namespace Iterator
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }

    class LocalCustomer : Customer
    {
        public LocalCustomer(string name, int id) : base(name, id)
        {
        }
    }

    class InternationalCustomer : Customer
    {
        public InternationalCustomer(string name, int id) : base(name, id)
        {
        }
    }
    
    interface IAbstractIterator
    {
        Customer First();
        Customer Next();
        bool IsCompleted { get; }
    }

    class Iterator : IAbstractIterator
    {
        private readonly ConcreteCollection _collection;
        private int _current;
        private readonly int _step = 1;
        public Iterator(ConcreteCollection collection)
        {
            _collection = collection;
        }
        public Customer First()
        {
            _current = 0;
            return _collection.GetCustomer(_current);
        }
        public Customer Next()
        {
            _current += _step;
            return !IsCompleted ? _collection.GetCustomer(_current) : null;
        }
        public bool IsCompleted => _current >= _collection.Count;
    }

    interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    class ConcreteCollection : IAbstractCollection
    {
        private readonly List<Customer> _listCustomers = new List<Customer>();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
        public int Count => _listCustomers.Count;

        public void AddCustomer(Customer customer)
        {
            _listCustomers.Add(customer);
        }
        public Customer GetCustomer(int indexPosition)
        {
            return _listCustomers[indexPosition];
        }
    }
    
    public static class Program
    {
        public static void Main()
        {
            var collection = new ConcreteCollection();
            collection.AddCustomer(new Customer("mfk", 1));
            collection.AddCustomer(new Customer("mfk2", 2));
            collection.AddCustomer(new LocalCustomer("mfk3", 3));
            collection.AddCustomer(new LocalCustomer("mfk4", 4));
            collection.AddCustomer(new InternationalCustomer("mfk5", 5));
            collection.AddCustomer(new InternationalCustomer("mfk6", 6));
            
            var iterator = collection.CreateIterator();
            
            Console.WriteLine("Iterating over collection:");
            
            for (var customer = iterator.First(); !iterator.IsCompleted; customer = iterator.Next())
            {
                Console.WriteLine($"ID : {customer.Id} & Name : {customer.Name}");
            }
            Console.Read();
        }
    }
}