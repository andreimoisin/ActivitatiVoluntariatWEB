using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Activitati
{
    public class IndexModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public IndexModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        public string NumeSortOrder { get; set; }
        public string DataSortOrder { get; set; }
        public string DepartamentSortOrder { get; set; }
        public string PunctajSortOrder { get; set; }

        public IList<Activitate> Activitate { get;set; } = default!;

        public async Task<IActionResult> OnGetSortByDateAsync()
        {
            var activitati = _context.Activitate.Include(a => a.Departament).Include(a => a.Responsabil).AsQueryable();

            activitati = activitati.OrderBy(a => a.Data);
            return Page();
        }


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NumeSortOrder = sortOrder == "nume_asc" ? "nume_desc" : "nume_asc";
            DataSortOrder = sortOrder == "data_asc" ? "data_desc" : "data_asc";
            DepartamentSortOrder = sortOrder == "dep_asc" ? "dep_desc" : "dep_asc";
            PunctajSortOrder = sortOrder == "pct_asc" ? "pct_desc" : "pct_asc";


            var activitati = _context.Activitate.Include(a => a.Departament).Include(a => a.Responsabil).AsQueryable();

            switch (sortOrder)
            {
                case "nume_desc":
                    activitati = activitati.OrderByDescending(a => a.NumeActivitate);
                    break;
                case "nume_asc":
                    activitati = activitati.OrderBy(a => a.NumeActivitate);
                    break;
                case "data_desc":
                    activitati = activitati.OrderByDescending(a => a.Data);
                    break;
                case "data_asc":
                    activitati = activitati.OrderBy(a => a.Data);
                    break;
                case "dep_desc":
                    activitati = activitati.OrderByDescending(a => a.Departament.NumeDepartament);
                    break;
                case "dep_asc":
                    activitati = activitati.OrderBy(a => a.Departament.NumeDepartament);
                    break;
                case "pct_desc":
                    activitati = activitati.OrderByDescending(a => a.Punctaj);
                    break;
                case "pct_asc":
                    activitati = activitati.OrderBy(a => a.Punctaj);
                    break;
                default:
                    activitati = activitati.OrderBy(a => a.NumeActivitate);
                    break;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                activitati = activitati.Where(a => a.NumeActivitate.Contains(searchString) ||
                                                   a.Departament.NumeDepartament.Contains(searchString) ||
                                                   a.Responsabil.NumeResponsabil.Contains(searchString));
            }

            Activitate = await activitati
            .Include(a => a.Departament)
            .Include(a => a.Responsabil)
            .ToListAsync();
        }
    }
}
