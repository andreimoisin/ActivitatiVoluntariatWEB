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
    public class DetailsModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DetailsModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

      public Activitate Activitate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Activitate == null)
            {
                return NotFound();
            }

            var activitate = await _context.Activitate.FirstOrDefaultAsync(m => m.ID == id);
            if (activitate == null)
            {
                return NotFound();
            }
            else 
            {
                Activitate = activitate;
            }
            return Page();
        }
    }
}
