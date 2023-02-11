using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Responsabili
{
    public class DeleteModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DeleteModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Responsabil Responsabil { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Responsabil == null)
            {
                return NotFound();
            }

            var responsabil = await _context.Responsabil.FirstOrDefaultAsync(m => m.ID == id);

            if (responsabil == null)
            {
                return NotFound();
            }
            else 
            {
                Responsabil = responsabil;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Responsabil == null)
            {
                return NotFound();
            }

            // verifica daca exista activitati asociate departamentului
            var activitati = await _context.Activitate.Where(a => a.ResponsabilID == Responsabil.ID).ToListAsync();

            if (activitati.Any())
            {
                // actualizeaza toate activitatile asociate responsabilului (responsabil = null)
                activitati.ForEach(a => a.Responsabil = null);
                _context.Activitate.UpdateRange(activitati);

            }

            // sterge responsabilul
            _context.Responsabil.Remove(Responsabil);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
