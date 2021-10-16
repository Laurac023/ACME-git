using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace presentacion.Pages
{
    public class CerrarSesionModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("UsuarioAutenticado");
            return RedirectToPage("../Index");
        }
    }
}
