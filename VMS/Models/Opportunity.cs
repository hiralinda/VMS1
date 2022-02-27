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
        /*Location*/
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ApplicationUser CreateUser { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
