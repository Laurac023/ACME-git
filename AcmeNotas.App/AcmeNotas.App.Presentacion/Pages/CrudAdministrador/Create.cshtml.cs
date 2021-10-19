using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudAdministrador
{
    public class CreateModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

  public SelectList listaMunicipios {get; set;}
        [BindProperty(SupportsGet =true)]
        public int MunicipioID {get; set;}
        [BindProperty]
        public String Mensaje {get; set;}

        public CreateModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        var listaMunicipiosBD = _context.Municipios.ToList();
            listaMunicipios = new SelectList(listaMunicipiosBD, nameof(Municipio.Id), nameof(Municipio.NombreMunicipio));//, new {onchange = @"Model.ChangeValue();"});

            return Page();
        }

        [BindProperty]
        public Administrador Administrador { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Municipio municipio = _context.Municipios.FirstOrDefault(p => p.Id == MunicipioID);
            Rol RolDB = _context.Roles.FirstOrDefault(r =>  r.NombreRol ==  "Administrador");
            Administrador.MunicipioPersona =municipio;
            Administrador.RolPersona = RolDB;
            Administrador.Password = Administrador.Cedula;
            Administrador.PrimerRegistro = true;
            Administrador.CodigoAdm= "A-"+Administrador.CodigoAdm;

            _context.Administradores.Add(Administrador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
