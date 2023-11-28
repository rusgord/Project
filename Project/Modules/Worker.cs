using Project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Worker : IPerson
    {
        public int Id { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override int Age { get; set; }
        public Job Job { get; set; }
        public Worker(int id, string name, string surname, int age, Job job)
        {
            Id = id;
            FirstName = name;
            LastName = surname;
            Age = age;
            Job = job;
        }
    }
}
