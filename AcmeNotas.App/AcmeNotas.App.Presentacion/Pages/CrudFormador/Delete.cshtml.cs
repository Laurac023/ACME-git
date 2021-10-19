using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudFormador
{
    public class DeleteModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public DeleteModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public Formador Formador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Formador = await _context.Formadores.FirstOrDefaultAsync(m => m.Id == id);
            
            if (Formador == null)
            {
                return NotFound();
            }
            //Municipio municipio = _context.Municipios.FirstOrDefault(p => p.Id == Formador.MunicipioPersona.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Formador = await _context.Formadores.FindAsync(id);

            if (Formador != null)
            {
                _context.Formadores.Remove(Formador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
