using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ActivitatiVoluntariatWEB.Pages.Departamente
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public CreateModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Departament Departament { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departament.Add(Departament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
