using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contrataciones.Data;
using Contrataciones.Models;

namespace Contrataciones.Pages.Trabajadores
{
    public class DetailsModel : PageModel
    {
        private readonly Contrataciones.Data.ContratacionesContext _context;

        public DetailsModel(Contrataciones.Data.ContratacionesContext context)
        {
            _context = context;
        }

        public Trabajador Trabajador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trabajador = await _context.Trabajador
                .Include(s => s.Contratos)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Trabajador == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
