using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuoteServiceDotNet
{
    public class Instrument
    {
        public string Name { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public string Exch { get; set; }
        
    }
}
