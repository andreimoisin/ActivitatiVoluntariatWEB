using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Activitati
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
            ViewData["ResponsabilID"] = new SelectList(_context.Set<Responsabil>(), "ID", "NumeResponsabil");
            ViewData["DepartamentID"] = new SelectList(_context.Set<Departament>(), "ID", "NumeDepartament");
            return Page();
        }

        [BindProperty]
        public Activitate Activitate { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Activitate.Add(Activitate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
