using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious
{
    public class Tag
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Tag()
        {
        }

        public Tag(string name)
        {
            Name = name;
        }
    }
}
