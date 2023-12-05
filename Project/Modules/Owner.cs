using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{
    public class Owner : IPerson, ICloneable, ITest
    {
        public int Income { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override int Age { get; set; }
        public Owner(string name, string surname, int age, int income)
        {
            FirstName = name;
            LastName = surname;
            Age = age;
            Income = income;
        }
        public object Clone()
        {
            return new Owner(FirstName, LastName, Age, Income);
        }
        public void IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || text == " " || text == "") throw new ArgumentException("Invalid Type");
        }
        public void NormalAge(int age)
        {
            if (age < 18 || age > 70) throw new ArgumentException("Invalid Type");
        }
        public void Enough(int income) 
        {
            if (income < 0) throw new ArgumentException("Invalid Type");
        }
    }
}
