using System;

namespace MyBI
{
    public class DataItem
    {
        public int iD { get; set; }
        public Region Region { get; set; }
        public Product Product { get; set; }
        public DateTime Month { get; set; }
        public double Revenue { get; set; }
        public double Units { get; set; }
    }
}
