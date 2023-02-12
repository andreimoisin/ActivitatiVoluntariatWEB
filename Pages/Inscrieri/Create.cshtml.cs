using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Inscrieri
{
    public class CreateModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public CreateModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ActivitateID"] = new SelectList(_context.Activitate, "ID", "NumeActivitate");
        ViewData["VoluntarID"] = new SelectList(_context.Voluntar, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Inscriere Inscriere { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inscriere.Add(Inscriere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
