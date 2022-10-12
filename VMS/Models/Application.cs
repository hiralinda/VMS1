using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Application
    {
            
            public enum ApplicationStatus
            {
                Pending,
                Approved,
                Denied
            }
            public int Id { get; set; }
            public int OppId { get; set; }
            public int VolsNeeded { get; set; }
            public Opportunity Opportunity { get; set; }
            public string OppName { get; set; }
            public string OppDate { get; set; }
            public string OppTime { get; set; }
            public string OppLocation { get; set; }
            public ApplicationUser Volunteer { get; set; }
            public string VolunteerName { get; set; }
            public int Status { get; set; }
            public bool IsVirtual { get; set; }
            public string AboutYou { get; set; }
            public string InstagramLink { get; set; }
            public string FacebookLink { get; set; }
            public string TwitterLink { get; set; }
            public string OtherWebsite { get; set; }
            public string School { get; set; }
    }
}
