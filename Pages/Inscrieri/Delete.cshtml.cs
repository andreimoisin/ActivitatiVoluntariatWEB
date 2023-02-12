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
    public class DeleteModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DeleteModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscriere == null)
            {
                return NotFound();
            }
            var inscriere = await _context.Inscriere.FindAsync(id);

            if (inscriere != null)
            {
                Inscriere = inscriere;
                _context.Inscriere.Remove(Inscriere);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
