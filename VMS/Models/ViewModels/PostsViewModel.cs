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
        public DateTime datePosted { get; set; }
        public ApplicationUser createUser { get; set; }
        public string createUserName { get; set; }
        public int totalLikes { get; set; }
        public byte[] ProfilePicture { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
