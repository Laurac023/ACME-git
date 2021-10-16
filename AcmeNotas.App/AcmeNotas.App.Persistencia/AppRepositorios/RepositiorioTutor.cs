using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia

{
     public class RepositorioTutor : IRepositorioTutor
     {
         private readonly Conexion _appContext;
         public RepositorioTutor (Conexion appContext)
         {
             _appContext = appContext;
         }

        public Tutor AddTutores(Tutor tutor)
         {
             var TutorAdicionado=  _appContext.Tutores.Add(tutor);
            _appContext.SaveChanges();
             return TutorAdicionado.Entity;
         }
         public void DeleteTutor(int IdTutor)
        {
            var TutorEncontrado= _appContext.Tutores.FirstOrDefault(p =>p.Id==IdTutor);
            if (TutorEncontrado ==null)
             return;
             _appContext.Tutores.Remove(TutorEncontrado);
             _appContext.SaveChanges();

        }

        public IEnumerable<Tutor> GetAllTutores()
        {
             return _appContext.Tutores;
        }


       public Tutor GetTutor(int IdTutor)
        {
            return _appContext.Tutores.FirstOrDefault(p =>p.Id==IdTutor);


        }

        public Tutor UpdateTutor(Tutor tutor)
        {
         var TutorEncontrado= _appContext.Tutores.FirstOrDefault(p =>p.Id==tutor.Id);    
         if (TutorEncontrado!=null)
         {
             TutorEncontrado.Cedula=tutor.Cedula;
             TutorEncontrado.Nombres = tutor.Nombres;
             TutorEncontrado.Apellidos= tutor.Apellidos;
             TutorEncontrado.Direccion=tutor.Direccion;
             TutorEncontrado.Telefono=tutor.Telefono;
             TutorEncontrado.Celular=tutor.Celular;
             TutorEncontrado.CorreoElectronico=tutor.CorreoElectronico;
             TutorEncontrado.Departamento = tutor.Departamento;
             TutorEncontrado.Municipio= tutor.Municipio;
             TutorEncontrado.Usuario=tutor.Usuario;
             TutorEncontrado.Password=tutor.Password;
             

             _appContext.SaveChanges();
          }
           return TutorEncontrado;
   
         }
     }
}
