using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ActivitatiVoluntariatWEB.Pages.Departamente
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DeleteModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Departament Departament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            var departament = await _context.Departament.FirstOrDefaultAsync(m => m.ID == id);

            if (departament == null)
            {
                return NotFound();
            }
            else 
            {
                Departament = departament;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departament == null)
            {
                return NotFound();
            }

            // verifica daca exista activitati asociate departamentului
            var activitati = await _context.Activitate.Where(a => a.DepartamentID == Departament.ID).ToListAsync();


            // verifica daca exista voluntari asociati departamentului
            var voluntari = await _context.Voluntar.Where(a => a.DepartamentID == Departament.ID).ToListAsync();

            if (activitati.Any())
            {
                // actualizeaza toate activitatile asociate departamentului (dep = null)
                activitati.ForEach(a => a.Departament = null);
                _context.Activitate.UpdateRange(activitati);

            }

            if (voluntari.Any())
            {
                // actualizeaza toti voluntarii asociati departamentului (dep = null)
                voluntari.ForEach(a => a.Departament = null);
                _context.Voluntar.UpdateRange(voluntari);
            }

            // sterge departamentul
            _context.Departament.Remove(Departament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
