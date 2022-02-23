using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMS.Models
{
    public class Application
    {
        public int id { get; set; }
        public ApplicationUser nonprofit { get; set; }
        public ApplicationUser volunteer { get; set; }
        public string questionResponse { get; set; }
        public bool status { get; set; }
    }
}
