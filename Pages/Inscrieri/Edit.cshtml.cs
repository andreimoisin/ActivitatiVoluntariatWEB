using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Inscrieri
{
    public class EditModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public EditModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscriere == null)
            {
                return NotFound();
            }

            var inscriere =  await _context.Inscriere.FirstOrDefaultAsync(m => m.ID == id);
            if (inscriere == null)
            {
                return NotFound();
            }
            Inscriere = inscriere;
           ViewData["ActivitateID"] = new SelectList(_context.Activitate, "ID", "NumeActivitate");
           ViewData["VoluntarID"] = new SelectList(_context.Voluntar, "ID", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inscriere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriereExists(Inscriere.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InscriereExists(int id)
        {
          return _context.Inscriere.Any(e => e.ID == id);
        }
    }
}
