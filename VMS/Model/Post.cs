using System;
using System.Collections.Generic;
using VMS.Models;

namespace VMS.Model
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public byte[] Image { get; set; }
        public string CreateUserId { get; set; }
        public DateTime DatePosted { get; set; }
        public int TotalLikes { get; set; }
        public string CreateUserName { get; set; }
        public byte[] ProfilePicture { get; set; }

        public virtual ApplicationUser CreateUser { get; set; }
    }
}
