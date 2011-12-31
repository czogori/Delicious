using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delicious
{
    public class Post
    {
        public string Description { get; set; }
        public string Extended { get; set; }
        public string Hash { get; set; }
        public string Url { get; set; }
        public bool Private { get; set; }
        public bool Shared { get; set; }        
        public DateTime Time{ get; set; }
        public List<Tag> Tags { get; set; }
    }
}
