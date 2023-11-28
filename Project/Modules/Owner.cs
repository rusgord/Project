using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{
    public class Owner : IPerson, ICloneable
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
    }
}
