using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models.ViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string Phone {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NonprofitName { get; set; }
    }
}
