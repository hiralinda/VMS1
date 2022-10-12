using System;
using System.Collections.Generic;

namespace VMS.Model
{
    public partial class Volunteer
    {
        public Volunteer()
        {
            Opportunities = new HashSet<Opportunity>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Preferences { get; set; }
        public string Skills { get; set; }
        public string Availability { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string Licenses { get; set; }
        public string EmergName { get; set; }
        public string EmergPhone { get; set; }
        public string EmergEmail { get; set; }
        public string EmergAdd { get; set; }
        public string ApprovalStatus { get; set; }
        public string ActiveStatus { get; set; }

        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}
