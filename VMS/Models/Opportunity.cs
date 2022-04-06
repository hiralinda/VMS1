using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public int VolunteersNeeded { get; set; }
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
        public string AgeBracket { get; set; }
        public string GradeLevel { get; set; }
        public string InterestAreas { get; set; }
        public string TypeOfOpportunity { get; set; }
        public bool Virtual { get; set; }
        public bool GroupActivity { get; set; }
        public bool OnGoing { get; set; } // Event is ongoing, no set end date
        public bool ArchivedStatus { get; set; }
        public DateTime ArchivedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ApplicationUser CreateUser { get; set; }
        public DateTime CreateDate { get; set; }

        public byte[] CompanyLogo { get; set; }
    }
}
