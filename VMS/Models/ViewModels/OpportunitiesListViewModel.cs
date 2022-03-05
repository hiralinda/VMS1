using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models.ViewModels
{
    public class OpportunitiesListViewModel
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
