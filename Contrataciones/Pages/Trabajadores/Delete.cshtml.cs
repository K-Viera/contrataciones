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
    public class DeleteModel : PageModel
    {
        private readonly Contrataciones.Data.ContratacionesContext _context;

        public DeleteModel(Contrataciones.Data.ContratacionesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trabajador Trabajador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trabajador = await _context.Trabajador.FirstOrDefaultAsync(m => m.ID == id);

            if (Trabajador == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trabajador = await _context.Trabajador.FindAsync(id);

            if (Trabajador != null)
            {
                _context.Trabajador.Remove(Trabajador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
