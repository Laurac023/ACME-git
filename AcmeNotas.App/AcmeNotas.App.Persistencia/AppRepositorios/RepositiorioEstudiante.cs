using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia

{
     public class RepositorioEstudiante : IRepositorioEstudiante
     {
         private readonly Conexion _appContext;
         public RepositorioEstudiante (Conexion appContext)
         {
             _appContext = appContext;
         }

        public Estudiante AddEstudiantes(Estudiante estudiante)
         {
             var EstudianteAdicionado=  _appContext.Estudiantes.Add(estudiante);
            _appContext.SaveChanges();
             return EstudianteAdicionado.Entity;
         }
         public void DeleteEstudiante(int IdEstudiante)
        {
            var EstudianteEncontrado= _appContext.Estudiantes.FirstOrDefault(p =>p.Id==IdEstudiante);
            if (EstudianteEncontrado ==null)
             return;
             _appContext.Estudiantes.Remove(EstudianteEncontrado);
             _appContext.SaveChanges();

        }

        public IEnumerable<Estudiante> GetAllEstudiantes()
        {
             return _appContext.Estudiantes;
        }


       public Estudiante GetEstudiante(int IdEstudiante)
        {
            return _appContext.Estudiantes.FirstOrDefault(p =>p.Id==IdEstudiante);


        }

        public Estudiante UpdateEstudiante(Estudiante estudiante)
        {
         var EstudianteEncontrado= _appContext.Estudiantes.FirstOrDefault(p =>p.Id==estudiante.IdE );    
         if (EstudianteEncontrado!=null)
         {
             EstudianteEncontrado.Cedula=estudiante.Cedula;
             EstudianteEncontrado.Nombres = estudiante.Nombres;
             EstudianteEncontrado.Apellidos= estudiante.Apellidos;
             EstudianteEncontrado.Direccion=estudiante.Direccion;
             EstudianteEncontrado.Telefono=estudiante.Telefono;
             EstudianteEncontrado.Celular=estudiante.Celular;
             EstudianteEncontrado.CorreoElectronico=estudiante.CorreoElectronico;
             EstudianteEncontrado.Departamento = estudiante.Departamento;
             EstudianteEncontrado.Municipio= estudiante.Municipio;
             EstudianteEncontrado.Usuario=estudiante.Usuario;
             EstudianteEncontrado.Password=estudiante.Password;
             
             _appContext.SaveChanges();
          }
           return EstudianteEncontrado;
   
         }
     }
}
