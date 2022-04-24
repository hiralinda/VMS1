using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string zip { get; set; }
        public string address { get; set; }
        public string school { get; set; }
        public bool isStudent { get; set; }
        public DateTime birthdate { get; set; }
        public string AboutYou { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
    }
}
