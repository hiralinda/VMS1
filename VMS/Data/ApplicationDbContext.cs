using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.Models;

namespace VMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VMS.Models.Volunteer> Volunteer { get; set; }
        public DbSet<VMS.Models.Opportunity> Opportunity { get; set; }
    }
}
