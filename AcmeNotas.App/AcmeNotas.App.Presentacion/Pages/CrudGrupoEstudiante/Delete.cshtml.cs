using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudGrupoEstudiante
{
    public class DeleteModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public DeleteModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        [BindProperty]
        public GrupoEstudiante GrupoEstudiante { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GrupoEstudiante = await _context.GrupoEstudiantes.FirstOrDefaultAsync(m => m.Id == id);

            if (GrupoEstudiante == null)
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

            GrupoEstudiante = await _context.GrupoEstudiantes.FindAsync(id);

            if (GrupoEstudiante != null)
            {
                _context.GrupoEstudiantes.Remove(GrupoEstudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
