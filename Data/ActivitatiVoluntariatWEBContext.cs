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

        public DbSet<ActivitatiVoluntariatWEB.Models.Departament> Departament { get; set; }

        public DbSet<ActivitatiVoluntariatWEB.Models.Voluntar> Voluntar { get; set; }

        public DbSet<ActivitatiVoluntariatWEB.Models.Inscriere> Inscriere { get; set; }
    }
}
