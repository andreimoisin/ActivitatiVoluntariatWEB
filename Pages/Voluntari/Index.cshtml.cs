using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;
using Microsoft.Data.SqlClient;

namespace ActivitatiVoluntariatWEB.Pages.Voluntari
{
    public class IndexModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public IndexModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        public string DepartamentSortOrder { get; set; }

        public string NumeSortOrder { get; set; }

        public IList<Voluntar> Voluntar { get;set; } = default!;

        public async Task<IActionResult> OnGetSortByNameAsync()
        {
            var voluntari = _context.Voluntar.Include(a => a.Departament).AsQueryable();

            voluntari = voluntari.OrderBy(a => a.Nume);
            return Page();
        }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            DepartamentSortOrder = sortOrder == "dep_asc" ? "dep_desc" : "dep_asc";

            NumeSortOrder = sortOrder == "nume_asc" ? "nume_desc" : "nume_asc";

            var voluntari = _context.Voluntar
                .Include(a => a.Departament)
                .AsQueryable();

            switch (sortOrder)
            {
                case "nume_desc":
                    voluntari = voluntari.OrderByDescending(a => a.Nume);
                    break;
                case "nume_asc":
                    voluntari = voluntari.OrderBy(a => a.Nume);
                    break;
                case "dep_desc":
                    voluntari = voluntari.OrderByDescending(a => a.Departament.NumeDepartament);
                    break;
                case "dep_asc":
                    voluntari = voluntari.OrderBy(a => a.Departament.NumeDepartament);
                    break;
                default:
                    voluntari = voluntari.OrderBy(a => a.Nume);
                    break;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                voluntari = voluntari.Where(a => a.Nume.Contains(searchString) ||
                                                   a.Prenume.Contains(searchString) ||
                                                   a.Departament.NumeDepartament.Contains(searchString));
            }

            Voluntar = await voluntari
            .Include(a => a.Departament)
            .ToListAsync();
        }
    }
}
