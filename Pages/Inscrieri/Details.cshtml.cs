using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Inscrieri
{
    public class DetailsModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DetailsModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

      public Inscriere Inscriere { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscriere == null)
            {
                return NotFound();
            }

            var inscriere = await _context.Inscriere
                .Include(a => a.Voluntar)
                .Include(a => a.Activitate)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (inscriere == null)
            {
                return NotFound();
            }
            else 
            {
                Inscriere = inscriere;
            }
            return Page();
        }
    }
}
