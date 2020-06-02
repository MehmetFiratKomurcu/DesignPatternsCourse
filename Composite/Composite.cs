using System;
using System.Collections.Generic;

namespace Composite
{
    public static class Program
    {
        public static void Main()
        {
            Intern mfk = new Intern("mfk", 0);
            Intern ark = new Intern("ark", 0);
            
            Intern mehmet = new Intern("mehmet", 0);
            Intern fırat = new Intern("fırat", 1);
            
            LeadDeveloper komurcu = new LeadDeveloper("Komurcu", 6);
            LeadDeveloper ali = new LeadDeveloper("Komurcu", 8);
            
            komurcu.AddSoftwareEngineer(mfk);
            komurcu.AddSoftwareEngineer(ark);
            
            ali.AddSoftwareEngineer(mehmet);
            ali.AddSoftwareEngineer(fırat);
            
            komurcu.DescribeYourself();
            ali.DescribeYourself();
            
        }
    }

    public interface ISoftwareEngineer
    {
        void DescribeYourself();
    }

    public class Intern : ISoftwareEngineer
    {
        private readonly string _name;
        private readonly long _experience;

        public Intern(string name, long experience)
        {
            _name = name;
            _experience = experience;
        }
        
        public void DescribeYourself()
        {
            Console.WriteLine($"I am {_name} and I have {_experience} year experience");
        }
    }
    
    public class LeadDeveloper : ISoftwareEngineer
    {
        private readonly string _name;
        private readonly long _experience;
        
        private readonly List<ISoftwareEngineer> _softwareEngineers = new List<ISoftwareEngineer>();

        public LeadDeveloper(string name, long experience)
        {
            _name = name;
            _experience = experience;
        }

        public void AddSoftwareEngineer(ISoftwareEngineer softwareEngineer)
        {
            _softwareEngineers.Add(softwareEngineer);
        }
        
        public void RemoveSoftwareEngineer(ISoftwareEngineer softwareEngineer)
        {
            _softwareEngineers.Remove(softwareEngineer);
        }
        
        public void DescribeYourself()
        {
            Console.WriteLine($"I am {_name}, I have {_experience} year experience and I'm leading these people: ");
            foreach (var softwareEngineer in _softwareEngineers)
            {
                softwareEngineer.DescribeYourself();
            }
        }
    }
}