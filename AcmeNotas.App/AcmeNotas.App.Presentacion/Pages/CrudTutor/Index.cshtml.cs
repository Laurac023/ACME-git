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
    public class IndexModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public IndexModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        public IList<Tutor> Tutor { get;set; }

        public async Task OnGetAsync()
        {
            Tutor = await _context.Tutores.ToListAsync();
        }
    }
}
