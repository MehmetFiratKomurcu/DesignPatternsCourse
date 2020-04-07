using System;

namespace Singleton
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Hero.HeroInstance.Attack();
            Hero.HeroInstance.Die();
            Hero.HeroInstance.HeroName = "Firat";
            Console.WriteLine(Hero.HeroInstance.HeroName);
        }
    }

    public sealed class Hero
    {
        public string HeroName { get; set; } // Singleton Property
        private Hero() // private constructor
        {
            
        }
        
        private static readonly Lazy<Hero> Lazy = new Lazy<Hero>(() => new Hero()); // Create thread safe singleton instance with Lazy.

        public static Hero HeroInstance => Lazy.Value; // return singleton instance

        public void Attack() // an instance function
        {
            Console.WriteLine("Hero attacked!");
        }

        public void Die() // an instance function
        {
            Console.WriteLine("Hero Died!");
        }
    }
}