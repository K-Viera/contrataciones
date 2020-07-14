using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contrataciones.Data;
using Contrataciones.Models;

namespace Contrataciones.Pages.Contratos
{
    public class DeleteModel : PageModel
    {
        private readonly Contrataciones.Data.ContratacionesContext _context;

        public DeleteModel(Contrataciones.Data.ContratacionesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contrato Contrato { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contrato = await _context.Contratos
                .Include(c => c.Trabajador).FirstOrDefaultAsync(m => m.ContratoID == id);

            if (Contrato == null)
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

            Contrato = await _context.Contratos.FindAsync(id);

            if (Contrato != null)
            {
                _context.Contratos.Remove(Contrato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
