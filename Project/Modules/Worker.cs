using Project.Enums;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Worker : IPerson, ITest
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
        public void IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text) || text == " " || text == "") throw new ArgumentException("Invalid Type");
        }
        public void NormalAge(int age)
        {
            if (age < 18 || age > 70) throw new ArgumentException("Invalid Type");
        }
        public void Enough(int id)
        {
            if (id < 0) throw new ArgumentException("Invalid Type");
        }
    }
}
