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
    public class DetailsModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DetailsModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

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
    }
}
