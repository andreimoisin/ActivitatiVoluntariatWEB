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

namespace ActivitatiVoluntariatWEB.Pages.Voluntari
{
    public class EditModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public EditModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voluntar Voluntar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Voluntar == null)
            {
                return NotFound();
            }

            var voluntar =  await _context.Voluntar.FirstOrDefaultAsync(m => m.ID == id);
            if (voluntar == null)
            {
                return NotFound();
            }
            Voluntar = voluntar;
           ViewData["DepartamentID"] = new SelectList(_context.Departament, "ID", "NumeDepartament");
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

            _context.Attach(Voluntar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoluntarExists(Voluntar.ID))
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

        private bool VoluntarExists(int id)
        {
          return _context.Voluntar.Any(e => e.ID == id);
        }
    }
}
