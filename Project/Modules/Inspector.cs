using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Inspector : IPrintable
    {
        int? rating;
        public int? Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnRatingChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public event EventHandler OnRatingChanged;
        public Restaurant Restaurant { get; set; }
        public Inspector(Restaurant restaurant, int? rating) 
        {
            Rating = rating;
            Restaurant = restaurant;
        }
        public Func<string> ToStringDelegate => () =>
        {
            if (Rating == null)
            {
                return $"Restaurant: {Restaurant.Name} - not rated";
            }
            else
                return $"Restaurant: {Restaurant.Name}, rating - {Rating}";
        };
        public static Func<int, List<Inspector>, int> Action = (count, list) =>
        {
            foreach (var item in list)
            {
                if (item.Rating != null) count++;
            }
            return count;
        };
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
