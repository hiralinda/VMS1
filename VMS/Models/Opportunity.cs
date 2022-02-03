using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string OpportunityName { get; set; }
        public string Location { get; set; } // volunteers assigned centers
        public string Description { get; set; }        
        public ApplicationUser CreateUser { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
