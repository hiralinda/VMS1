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
        public string zip { get; set; }
        public string address { get; set; }
        public string phone {get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
