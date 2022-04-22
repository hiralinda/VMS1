using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public byte[] image { get; set; }
    }
}
