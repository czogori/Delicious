using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious.Models
{
    public class Bundle
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; }

        public Bundle()
        {
            Tags = new List<string>();
        }
    }
}
