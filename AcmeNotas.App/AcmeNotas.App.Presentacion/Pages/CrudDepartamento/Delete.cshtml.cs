using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CruDepartamento
{
    public class DeleteModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public DeleteModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public Departamento Departamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.Id == id);

            if (Departamento == null)
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

            Departamento = await _context.Departamentos.FindAsync(id);

            if (Departamento != null)
            {
                _context.Departamentos.Remove(Departamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
