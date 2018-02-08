using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.JSON
{
    public class Stock
    {
        public string Name { get; set; }
        public Price Price { get; set; }
        public double Percent_change { get; set; }
        public int Volume { get; set; }
        public string Symbol { get; set; }
    }
    public class Price
    {
        public string Currency { get; set; }

        public double Amount { get; set; }
    }
}
