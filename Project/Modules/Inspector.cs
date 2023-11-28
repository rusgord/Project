using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Inspector : IPrintable
    {
        public int? Rating { get; set; }
        public Restaurant Restaurant { get; set; }
        public Inspector(Restaurant restaurant, int? rating) 
        {
            Rating = rating;
            Restaurant = restaurant;
        }
        public override string ToString()
        {
            string result;
            if (Rating == null)
            {
                result = $"Restaurant: {Restaurant.Name} - not rated";
            }
            else 
                result = $"Restaurant: {Restaurant.Name}, rating - {Rating}";
            return result;
        }
        public string PrintToDisplay()
        {
            string result;
            if (Rating == null)
            {
                result = $"Restaurant: {Restaurant.Name} - not rated";
            }
            else
                result = $"Restaurant: {Restaurant.Name}, rating - {Rating}";
            result += $"\n{Restaurant.PrintToDisplay()}";
            return result;
        }
    }
}
