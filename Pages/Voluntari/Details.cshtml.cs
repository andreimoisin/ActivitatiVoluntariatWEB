using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActivitatiVoluntariatWEB.Data;
using ActivitatiVoluntariatWEB.Models;

namespace ActivitatiVoluntariatWEB.Pages.Voluntari
{
    public class DetailsModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public DetailsModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

      public Voluntar Voluntar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Voluntar == null)
            {
                return NotFound();
            }

            var voluntar = await _context.Voluntar
                .Include(a => a.Departament)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (voluntar == null)
            {
                return NotFound();
            }
            else 
            {
                Voluntar = voluntar;
            }
            return Page();
        }
    }
}
