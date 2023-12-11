using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    public class Restaurant : IPrintable
    {
        public string Name { get; set; }
        public Owner Owner { get; set; }
        public List<Worker> Workers { get; set; }
        public Restaurant(string name)
        {
            Name = name;
        }
        public Restaurant(string name, Owner owner, List<Worker> workers) : this(name)
        {
            Owner = owner;
            Workers = workers;
        }
        public void IsEmpty(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Invalid Type");
        }
        public override string ToString()
        {
            return $"{Owner.FirstName} {Owner.LastName}";
        }
        public string PrintToDisplay() 
        {
            string result = $"Owner: {Owner.FirstName} {Owner.LastName}, age - {Owner.Age}\nIncome: {Owner.Income}\n\nWorkers - {Workers.Count}";
            foreach (Worker worker in Workers) 
            {
                result += $"\nWorker {worker.Id}: {worker.FirstName} {worker.LastName}, age - {worker.Age}\nJob '{worker.JobCheck}'";
            }
            return result += "\n";
        }
    }
}
