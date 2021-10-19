using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AcmeNotas.App.Presentacion.Pages.CrudNota
{
    public class CreateModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public CreateModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }
        public SelectList estudiantes;

        [BindProperty]
        public int EstudianteID{get; set;}


        public IActionResult OnGet()
        {
            var UsuarioAutenticado = HttpContext.Session.GetString("Usuario");
            if (UsuarioAutenticado ==null) {
                UsuarioAutenticado = "MARIA";
            }
            
            var Formador = _context.Personas.FirstOrDefault(p => p.Usuario == UsuarioAutenticado);
            
            var Grupos = _context.Grupos.Where( g => g.Formador == Formador).ToList();

            List<Estudiante> listadoEstdiantes = new List<Estudiante>();
            foreach(Grupo g in Grupos){
                listadoEstdiantes.AddRange(_context.Estudiantes.Where( e => e.Grupo == g ).ToList());  
            }

            estudiantes = new SelectList(listadoEstdiantes, nameof(Estudiante.Id), nameof(Estudiante.Nombres), nameof(Estudiante.Grupo.CodigoGrupo), null);

            return Page();
        }

        [BindProperty]
        public Nota Nota { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Estudiante e = _context.Estudiantes.Include(g=>g.Grupo).FirstOrDefault(e => e.Id == EstudianteID);
            
            var valorCiclo = ValoresCiclo.ConvertirDatosCiclo(e.Grupo.Ciclo);
            Nota.NotaDefinitiva = (Nota.Nota1 * valorCiclo[0]) +  
                                  (Nota.Nota2 * valorCiclo[1]) + 
                                  (Nota.Nota3 * valorCiclo[2]) + 
                                  (Nota.Nota4 * valorCiclo[3]) + 
                                  (Nota.Nota5 * valorCiclo[4]);
            Nota.estudiante = e;

            _context.Notas.Add(Nota);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
