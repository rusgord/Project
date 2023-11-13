using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Owner : IPerson
    {
        public int Income { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Owner(string name, string surname, int age, int income)
        {
            throw new NotImplementedException();
        }
    }
}
