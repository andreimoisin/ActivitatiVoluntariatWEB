using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Data
{
    public class ActivitatiVoluntariatWEBContext : DbContext
    {
        public ActivitatiVoluntariatWEBContext (DbContextOptions<ActivitatiVoluntariatWEBContext> options)
            : base(options)
        {
        }

        public DbSet<ActivitatiVoluntariatWEB.Models.Activitate> Activitate { get; set; } = default!;

        public DbSet<ActivitatiVoluntariatWEB.Models.Responsabil> Responsabil { get; set; }
    }
}
