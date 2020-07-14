using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contrataciones.Data;
using Contrataciones.Models;

namespace Contrataciones.Pages.Contratos
{
    public class EditModel : PageModel
    {
        private readonly Contrataciones.Data.ContratacionesContext _context;

        public EditModel(Contrataciones.Data.ContratacionesContext context)
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
           ViewData["TrabajadorID"] = new SelectList(_context.Trabajadores, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(Contrato.ContratoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratoID == id);
        }
    }
}
