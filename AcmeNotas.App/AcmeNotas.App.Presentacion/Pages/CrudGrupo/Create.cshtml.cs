using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;
using Microsoft.AspNetCore.Components;

namespace AcmeNotas.App.Presentacion.Pages.CrudGrupo
{
    public class CreateModel : PageModel
    {
        private readonly AcmeNotas.App.Persistencia.Conexion _context;

        public SelectList listaFormadores {get; set;}

        public SelectList listaTutores {get; set;}
        public SelectList listaHorarios {get; set;}
        [BindProperty]
        public int FormadorID {get; set;}
        [BindProperty]
        public int HorarioID{get;set;}
        [BindProperty]
        public int TutorID {get; set;}

        [BindProperty]
        public String Mensaje {get; set;}

       

        public CreateModel(AcmeNotas.App.Persistencia.Conexion context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        var listaFormadoresBD = _context.Personas.Where(p => p.RolPersona.NombreRol == "Formador");
            listaFormadores = new SelectList(listaFormadoresBD, nameof(Persona.Id), nameof(Persona.Nombres), new {onchange = @"Model.ChangeValue();"});

        var listaHorariosBD = _context.Horarios;
            listaHorarios = new SelectList(listaHorariosBD, nameof(Horario.Id), nameof(Horario.CodigoHorario),null);

            return Page();
        }

        [BindProperty]
        public Grupo Grupo { get; set; }
        public JsonResult OnGetTutores(){
            var listaTutoresBD = _context.Personas.Where(p => p.RolPersona.NombreRol == "Tutor");        
            listaTutores = new SelectList(listaTutoresBD, nameof(Persona.Id), nameof(Persona.Nombres), null);
            return new JsonResult(listaTutores);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Persona formador = _context.Personas.FirstOrDefault(p => p.Id == FormadorID);
            Persona tutor = _context.Personas.FirstOrDefault(p => p.Id == TutorID);
            Horario horario = _context.Horarios.FirstOrDefault(h=> h.Id== HorarioID);
            var grupos = _context.Grupos.Where(g => g.Formador == formador).ToList();
            Grupo.Formador = formador;
            Grupo.Tutor = tutor;
            Grupo.CodigoGrupo ="G-"+Grupo.CodigoGrupo;
            // falta horario
            Grupo.Horario = horario;
            if(grupos.Count() >= 3){
                Mensaje = "Maximo de grupos alcanzado para el formador";
                
                return this.OnGet();
            }else{
            _context.Grupos.Add(Grupo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
}