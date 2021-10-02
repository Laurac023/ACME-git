using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia
{
    public class RepositorioAdministrador : IRepositorioAdministrador

    {
        private readonly AppContext _appContext;
        public RepositorioAdministrador(AppContext appContext)
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
             AdministradorEncontrado.Nombres= administrador.Nombres;
             AdministradorEncontrado.Apellidos= administrador.Apellidos;
             AdministradorEncontrado.Cedula=administrador.Cedula;
             AdministradorEncontrado.CorreoElectronico=administrador.CorreoElectronico;
             AdministradorEncontrado.Usuario=administrador.Usuario;
             AdministradorEncontrado.Password=administrador.Password;

             _appContext.SaveChanges();
          }
           return AdministradorEncontrado;
        }
    }
}