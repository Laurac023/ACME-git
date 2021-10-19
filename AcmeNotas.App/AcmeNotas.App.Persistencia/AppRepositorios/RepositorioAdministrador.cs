using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia
{
    public class RepositorioAdministrador : IRepositorioAdministrador

    {
        private readonly Conexion _appContext;
        public RepositorioAdministrador(Conexion appContext)
        {
            _appContext = appContext;
        }
        Administrador IRepositorioAdministrador.AddAdministrador(Administrador administrador)
        {
            var AdministradorAdicionado=  _appContext.Administradores.Add(administrador);
            _appContext.SaveChanges();
             return AdministradorAdicionado.Entity;

        }

        public void DeleteAdministrador(int IdAdministrador)
        {
            var AdministradorEncontrado= _appContext.Administradores.FirstOrDefault(p =>p.Id==IdAdministrador);
            if (AdministradorEncontrado ==null)
             return;
             _appContext.Administradores.Remove(AdministradorEncontrado);
             _appContext.SaveChanges();

        }

        public IEnumerable<Administrador> GetAllAdministradores()
        {
             return _appContext.Administradores;
        }


       public Administrador GetAdministrador(int IdAdministrador)
        {
            return _appContext.Administradores.FirstOrDefault(p =>p.Id==IdAdministrador);
        }

        public Administrador UpdateAdministrador(Administrador administrador)
        {
         var AdministradorEncontrado= _appContext.Administradores.FirstOrDefault(p =>p.Id==administrador.Id);    
         if (AdministradorEncontrado!=null)
         {
             AdministradorEncontrado.Cedula=administrador.Cedula;
             AdministradorEncontrado.Nombres = administrador.Nombres;
             AdministradorEncontrado.Apellidos= administrador.Apellidos;
             AdministradorEncontrado.Direccion=administrador.Direccion;
             AdministradorEncontrado.Telefono=administrador.Telefono;
             AdministradorEncontrado.Celular=administrador.Celular;
             AdministradorEncontrado.CorreoElectronico=administrador.CorreoElectronico;
             AdministradorEncontrado.MunicipioPersona = administrador.MunicipioPersona;
             AdministradorEncontrado.RolPersona= administrador.RolPersona;
             AdministradorEncontrado.Usuario=administrador.Usuario;
             AdministradorEncontrado.Password=administrador.Password;
             AdministradorEncontrado.PrimerRegistro=administrador.PrimerRegistro;
             _appContext.SaveChanges();
          }
           return AdministradorEncontrado;
        }
    }
}