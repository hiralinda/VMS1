using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    /*
     Describes the data model for the user that is
     associated with an organization     
     */
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string School { get; set; }
        public bool IsStudent { get; set; }
        public DateTime Birthdate { get; set; }
        public string AboutYou { get; set; }
        public string MissionStatement { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string OtherWebsite { get; set; }
    }
}
