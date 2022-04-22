using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models.ViewModels
{
    public class PostsViewModel
    {
        public string title { get; set; }
        public string body { get; set; }
        public byte[] image { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
