using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.Models;

namespace VMS.Data
{
    public class ApplicationDbContextBak : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContextBak(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VMS.Models.Volunteer> Volunteer { get; set; }
        public DbSet<VMS.Models.Opportunity> Opportunity { get; set; }
        public DbSet<VMS.Models.Organization> Organization { get; set; }
        public DbSet<VMS.Models.Application> Application { get; set; }
        public DbSet<VMS.Models.Post> Post { get; set; }
    }
}
