using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudTutor
{
    public class DetailsModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public DetailsModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        public Tutor Tutor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tutor = await _context.Tutores.FirstOrDefaultAsync(m => m.Id == id);

            if (Tutor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
