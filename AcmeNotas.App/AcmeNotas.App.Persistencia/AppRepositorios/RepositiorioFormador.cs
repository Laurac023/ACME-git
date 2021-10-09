using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia

{
     public class RepositorioFormador : IRepositorioFormador
     {
         private readonly Conexion _appContext;
         public RepositorioFormador (Conexion appContext)
         {
             _appContext = appContext;
         }

        public Formador AddFormadores(Formador formador)
         {
             var FormadorAdicionado=  _appContext.Formadores.Add(formador);
            _appContext.SaveChanges();
             return FormadorAdicionado.Entity;
         }
         public void DeleteFormador(int IdFormador)
        {
            var FormadorEncontrado= _appContext.Formadores.FirstOrDefault(p =>p.Id==IdFormador);
            if (FormadorEncontrado ==null)
             return;
             _appContext.Formadores.Remove(FormadorEncontrado);
             _appContext.SaveChanges();

        }

        public IEnumerable<Formador> GetAllFormadores()
        {
             return _appContext.Formadores;
        }


       public Formador GetFormador(int IdFormador)
        {
            return _appContext.Formadores.FirstOrDefault(p =>p.Id==IdFormador);

        }

        public Formador UpdateFormador(Formador formador)
        {
         var FormadorEncontrado= _appContext.Formadores.FirstOrDefault(p =>p.Id==formador.Id );    
         if (FormadorEncontrado!=null)
         {
             FormadorEncontrado.Cedula=formador.Cedula;
             FormadorEncontrado.Nombres = formador.Nombres;
             FormadorEncontrado.Apellidos= formador.Apellidos;
             FormadorEncontrado.Direccion=formador.Direccion;
             FormadorEncontrado.Telefono=formador.Telefono;
             FormadorEncontrado.Celular=formador.Celular;
             FormadorEncontrado.CorreoElectronico=formador.CorreoElectronico;
             FormadorEncontrado.Departamento = formador.Departamento;
             FormadorEncontrado.Municipio= formador.Municipio;
             FormadorEncontrado.Usuario=formador.Usuario;
             FormadorEncontrado.Password=formador.Password;
             
             _appContext.SaveChanges();
          }
           return FormadorEncontrado;
   
         }
     }
}
