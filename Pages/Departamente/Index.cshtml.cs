using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;
using ActivitatiVoluntariatWEB.Models.ViewModels;

namespace ActivitatiVoluntariatWEB.Pages.Departamente
{
    public class IndexModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public IndexModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        public IList<Departament> Departament { get;set; } = default!;

        public DepartamentIndexData DepartamentData { get; set; }
        public int DepartamentID { get; set; }
        public int ActivitateID { get; set; }

        public async Task OnGetAsync(int? id, int? activitateID)
        {
            DepartamentData = new DepartamentIndexData();
            DepartamentData.Departamente = await _context.Departament
                .Include(i => i.Activitati)
                .ToListAsync();

            if(id != null)
            {
                DepartamentID = id.Value;
                Departament dep = DepartamentData.Departamente
                    .Where(i => i.ID == id.Value).Single();
                DepartamentData.Activitati = dep.Activitati;
            }


            if (_context.Departament != null)
            {
                Departament = await _context.Departament.ToListAsync();
            }
        }
    }
}
