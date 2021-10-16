using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AcmeNotas.App.Persistencia;
using Microsoft.AspNetCore.Http;

namespace AcmeNotas.App.Presentacion.Pages
{
    public class CambiarPaswordModel : PageModel
    {
        
        [BindProperty]
        public string Password {get; set;}

        [BindProperty]
        public string RepeatPassword {get; set;}

        [BindProperty]
        public string Mensaje {get; set;}



        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Conexion conexion = new Conexion();
             var usuario = HttpContext.Session.GetString("Usuario");
             var p = conexion.Personas.FirstOrDefault(p => p.Usuario == usuario);
             if(Password.Equals(RepeatPassword)){
                 Mensaje = "El password ha cambiado";
                 p.Password = RepeatPassword;
                 p.PrimerRegistro = false;
                 conexion.SaveChanges();
                return RedirectToPage("../Index");
             }else{
                 Mensaje = "Las contraseñas no coinciden";
                 return Page();
             }
        }
    }
}
