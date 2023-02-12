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
    public class IndexModel : PageModel
    {
        private readonly ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext _context;

        public IndexModel(ActivitatiVoluntariatWEB.Data.ActivitatiVoluntariatWEBContext context)
        {
            _context = context;
        }

        public IList<Voluntar> Voluntar { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Voluntar != null)
            {
                Voluntar = await _context.Voluntar
                .Include(v => v.Departament).ToListAsync();
            }
        }
    }
}
