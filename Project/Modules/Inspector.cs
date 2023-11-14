using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Inspector : IPrintable
    {
        public int Rating { get; set; }
        public Inspector(Restaurant restaurant, int rating) 
        {
            throw new NotImplementedException();
        }
        public string PrintToDisplay()
        {
            throw new NotImplementedException();
        }
    }
}
