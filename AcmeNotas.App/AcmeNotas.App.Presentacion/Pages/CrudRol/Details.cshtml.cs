using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudRol
{
    public class DetailsModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public DetailsModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        public Rol Rol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rol = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (Rol == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
