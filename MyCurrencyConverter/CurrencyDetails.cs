using System;
using System.Collections.Generic;
using System.Text;

namespace MyCurrencyConverter
{
    public class Rates
    {
        
        
        public double AUD { get; set; }
        
        public double EGP { get; set; }

        public double EUR { get; set; }
        public double GBP { get; set; }

        public double NOK { get; set; }
        public double NZD { get; set; }



    }

    public class RootObject
    {
        public string disclaimer { get; set; }
        public string license { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public Rates rates { get; set; }
    }
}

