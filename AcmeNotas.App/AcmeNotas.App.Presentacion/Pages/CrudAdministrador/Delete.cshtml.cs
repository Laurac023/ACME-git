using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudAdministrador
{
    public class DeleteModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public DeleteModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Administrador = await _context.Administradores.FirstOrDefaultAsync(m => m.Id == id);

            if (Administrador == null)
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

            Administrador = await _context.Administradores.FindAsync(id);

            if (Administrador != null)
            {
                _context.Administradores.Remove(Administrador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
