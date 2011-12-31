using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious.Models
{
    public class Suggest
    {
        public List<string> Popular { get; set; }
        public List<string> Recommended { get; set; }
        public List<string> Network { get; set; }

        public Suggest()
        {
            Popular = new List<string>();
            Recommended = new List<string>();
            Network = new List<string>();
        }
    }
}
