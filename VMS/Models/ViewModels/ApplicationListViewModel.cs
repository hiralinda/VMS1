using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models.ViewModels
{
    public class ApplicationListViewModel
    {
        public string volunteer { get; set; }
        public string address { get; set; }
        public string opportunityName { get; set; }
        public bool status { get; set; }
        public DateTime date { get; set; }
    }
}
