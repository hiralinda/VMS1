using System;
using System.Collections.Generic;
using VMS.Models;

namespace VMS.Model
{
    public partial class Application
    {
        public int Id { get; set; }
        public string VolunteerId { get; set; }
        public int Status { get; set; }
        public int? OpportunityId { get; set; }
        public string OppName { get; set; }
        public string VolunteerName { get; set; }
        public string OppDate { get; set; }
        public string OppLocation { get; set; }
        public int OppId { get; set; }
        public int VolsNeeded { get; set; }
        public string OppTime { get; set; }
        public string AboutYou { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string OtherWebsite { get; set; }
        public string School { get; set; }
        public string TwitterLink { get; set; }
        public bool? IsVirtual { get; set; }

        public virtual Opportunity Opportunity { get; set; }
        public virtual ApplicationUser Volunteer { get; set; }
    }
}
