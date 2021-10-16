using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeNotas.App.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace AcmeNotas.App.Presentacion
{
    public class LoginModel : PageModel
    {
        private AcmeNotas.App.Persistencia.Conexion conexion;

        [BindProperty]
        public string Usuario {get; set;}

        [BindProperty]
        public string Password {get; set;}

        [BindProperty]
        public string MensajeUsuario {get; set;}

        [BindProperty]
        public string MensajePassword {get; set;}
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            conexion = new App.Persistencia.Conexion();
            var p = conexion.Personas.Include(p=> p.RolPersona).FirstOrDefault(p => p.Usuario == Usuario);
            if(p == null ){
                MensajeUsuario = "El Usuario no existe";
            }else if(!p.Password.Equals(Password)){
                HttpContext.Session.SetString("Usuario", Usuario);
                MensajePassword = "El password no coincide";
            }else if(p.Password.Equals(Password) && p.PrimerRegistro){
                HttpContext.Session.SetString("Usuario", Usuario);
                return RedirectToPage("./CambiarPasword");
            }else{
                HttpContext.Session.SetString("Usuario", Usuario);
                HttpContext.Session.SetString("UsuarioAutenticado", p.RolPersona.NombreRol);
                return RedirectToPage("../Index");
            }
            return Page();
            
        }
    }
}
