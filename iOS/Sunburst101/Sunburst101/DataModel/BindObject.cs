using System;

namespace Sunburst101
{
    class BindObject : object
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public BindObject(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

    }
}