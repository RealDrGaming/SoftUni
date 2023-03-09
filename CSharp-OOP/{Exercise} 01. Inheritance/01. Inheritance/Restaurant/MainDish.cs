using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Restaurant
{
    public class MainDish : Food
    {
        public MainDish(string name, decimal price, double grams) : base(name, price, grams)
        {

        }
    }
}
