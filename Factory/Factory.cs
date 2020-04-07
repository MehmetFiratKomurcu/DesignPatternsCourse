using System;

namespace Factory
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            AnimalFactory factory = new AnimalFactory();
            var animal = factory.GetAnimal("Lion");
            Console.WriteLine(animal.Speak());
        }
    }

    public interface IAnimalFactory
    {
        IAnimal GetAnimal(string animalType);
    }

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal GetAnimal(string animalType)
        {
            if (animalType.Equals("Dog"))
            {
                return new Dog();
            }

            if (animalType.Equals("Cat"))
            {
                return new Cat();
            }

            if (animalType.Equals("Lion"))
            {
                return new Lion();
            }

            return null;
        }
    }

    public interface IAnimal
    {
        string Speak();
    }

    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "Meow Meow Meow!";
        }
    }

    public class Lion : IAnimal
    {
        public string Speak()
        {
            return "Roar!";
        }
    }

    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "Hav Hav!";
        }
    }
}