using Project.Enums;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public delegate void JobChangedHandlerDelegate(object sender, EventArgs e);
    public class Worker : Person, ITest
    {
        public event JobChangedHandlerDelegate OnJobChanged;
        public int Id { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override int Age { get; set; }
        private Job Job;
        public Job JobCheck
        {
            get { return Job; }
            set
            {
                Job = value;
                OnJobChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public Worker(int id, string name, string surname, int age, Job job)
        {
            Id = id;
            FirstName = name;
            LastName = surname;
            Age = age;
            JobCheck = job;
        }
        public void IsEmpty(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentException("Invalid Type");
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
