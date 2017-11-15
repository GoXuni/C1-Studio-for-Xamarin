using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChart101
{
    public class FruitEntity
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public FruitEntity(string name, double value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
