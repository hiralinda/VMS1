using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Opportunity
    {
        public int Id { get; set; }
        public string opportunityName { get; set; }
        public string center { get; set; } // volunteers assigned centers
        public string datePosted { get; set; }

        public Opportunity()
        {

        }
    }
}
