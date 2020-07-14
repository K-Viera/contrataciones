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
    public class IndexModel : PageModel
    {
        private readonly Contrataciones.Data.ContratacionesContext _context;

        public IndexModel(Contrataciones.Data.ContratacionesContext context)
        {
            _context = context;
        }

        public IList<Contrato> Contrato { get;set; }

        public async Task OnGetAsync()
        {
            Contrato = await _context.Contratos
                .Include(c => c.Trabajador).ToListAsync();
        }
    }
}
