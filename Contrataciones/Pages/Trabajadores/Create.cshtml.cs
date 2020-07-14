using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Contrataciones.Data;
using Contrataciones.Models;

namespace Contrataciones.Pages.Trabajadores
{
    public class CreateModel : PageModel
    {
        private readonly Contrataciones.Data.ContratacionesContext _context;

        public CreateModel(Contrataciones.Data.ContratacionesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trabajador Trabajador { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trabajador.Add(Trabajador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
