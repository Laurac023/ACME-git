using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Presentacion.Pages.CrudMunicipio
{
    public class CreateModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;
        Departamento Departamento {get;set;}
        public SelectList listaDepartamentos {get; set;}
        [BindProperty(SupportsGet =true)]
        public int DepartamentoID {get; set;}
         [BindProperty]
        public String Mensaje {get; set;}
        public CreateModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        var listaDepartamentosBD = _context.Departamentos;
        listaDepartamentos = new SelectList(listaDepartamentosBD, nameof(Departamento.Id), nameof(Departamento.NombreDepartamento ));//, new {onchange = @"Model.ChangeValue();"});

            return Page();
        }

        [BindProperty]
        public Municipio Municipio { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
                        Departamento departamento = _context.Departamentos.FirstOrDefault(p => p.Id == DepartamentoID);
            Municipio.Departamento = departamento;
            _context.Municipios.Add(Municipio);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
