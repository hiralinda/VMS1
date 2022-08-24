using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models.ViewModels
{
    public class PostsViewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public byte[] Image { get; set; }
        public DateTime DatePosted { get; set; }
        public ApplicationUser CreateUser { get; set; }
        public string CreateUserName { get; set; }
        public int TotalLikes { get; set; }
        public byte[] ProfilePicture { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
