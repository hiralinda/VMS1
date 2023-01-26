using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Opportunity
    {
        public Opportunity()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string OpportunityName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Requirements { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString =
		"{MM/dd/yyyy}",
		 ApplyFormatInEditMode = true)]
		public DateTime EndDate { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString =
	   "{MM/dd/yyyy}",
		ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

		public string AgeBracket { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string GradeLevel { get; set; }
        public string InterestAreas { get; set; }
        public int VolunteersNeeded { get; set; }
        public bool GroupActivity { get; set; }
        public string TypeOfOpportunity { get; set; }
        public bool Virtual { get; set; }
        public bool OnGoing { get; set; }
        public bool? ArchivedStatus { get; set; }
        public DateTime ArchivedDate { get; set; }
        public int VolunteersApplied { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public int? VolunteerId { get; set; }
        public bool IsRecurring { get; set; } = false;
        public string RecurringDays { get; set; } 

        public virtual ApplicationUser CreateUser { get; set; }
        public virtual Volunteer Volunteer { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
