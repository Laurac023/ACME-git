using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;

namespace AcmeNotas.App.Persistencia
{
    public class  RepositorioRol : IRepositorioRol

    {
        private readonly Conexion  _appContext;
        public RepositorioRol (Conexion appContext)
        {
            _appContext = appContext;
        }
    Rol IRepositorioRol.AddRol(Rol rol){
        var RolAdicionado =  _appContext.Roles.Add(rol);
            _appContext.SaveChanges();
             return RolAdicionado.Entity;
    }  
    public void DeleteRol(int IdRol)
    {
    var RolEncontrado= _appContext.Roles.FirstOrDefault(p =>p.Id==IdRol);
         if (RolEncontrado ==null)
         return;
             _appContext.Roles.Remove(RolEncontrado);
             _appContext.SaveChanges();    
    }
    public IEnumerable<Rol> GetAllRoles()
    {
        return _appContext.Roles;
    }
  public Rol GetRol(int IdRol)
  {
      return _appContext.Roles.FirstOrDefault(p =>p.Id  ==IdRol);
  }
  public Rol UpdateRol(Rol rol)  
  {
      var RolEncontrado= _appContext.Roles.FirstOrDefault(p =>p.Id== rol.Id);    
         if (RolEncontrado!=null)
         {
            RolEncontrado.CodigoRol = rol.CodigoRol;
            RolEncontrado.NombreRol= rol.NombreRol;
         }
         return RolEncontrado;  
  }
 }
}
