using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia

{
     public class RepositorioPersona : IRepositorioPersona
     {
         private readonly Conexion _appContext;
         public RepositorioPersona (Conexion appContext)
         {
             _appContext = appContext;
         }

        public Persona guardarPersona (Persona persona)
         {
             var PersonaAdicionada=  _appContext.Personass.Add(persona);
            _appContext.SaveChanges();
             return PersonaAdicionada.Entity;
         }
         public void eliminarPersona(int IdPersona)
        {
            var PersonaEncontrada= _appContext.Personas.FirstOrDefault(p =>p.Id==IdPersona);
            if (PersonaEncontrada ==null)
             return;
             _appContext.Personas.Remove(PersonaEncontrada);
             _appContext.SaveChanges();

        }

        public IEnumerable<Persona> consultarTodos()
        {
             return _appContext.Personas;
        }


       public Persona GetPersona(int IdPersona)
        {
            return _appContext.Personas.FirstOrDefault(p =>p.Id==IdPersona);


        }

        public Persona UpdatePersona(Persona persona)
        {
         var PersonaEncontrada= _appContext.Personas.FirstOrDefault(p =>p.Id==persona.Id);    
         if (PersonaEncontrada!=null)
         {
             PersonaEncontrada.Cedula=persona.Cedula;
             PersonaEncontrada.Nombres = persona.Nombres;
             PersonaEncontrada.Apellidos= persona.Apellidos;
             PersonaEncontrada.Direccion=persona.Direccion;
             PersonaEncontrada.Telefono=persona.Telefono;
             PersonaEncontrada.Celular=persona.Celular;
             PersonaEncontrada.CorreoElectronico=persona.CorreoElectronico;
             //TutorEncontrado.Departamento = tutor.Departamento;
             PersonaEncontrada.Municipio= persona.Municipio;
             PersonaEncontrada.Usuario=persona.Usuario;
             PersonaEncontrada.Password=persona.Password;
             PersonaEncontrada.PrimerRegistro= persona.PrimerRegistro;

             _appContext.SaveChanges();
          }
           return PersonaEncontrada;
   
         }
     }
}
