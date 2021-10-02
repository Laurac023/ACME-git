using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioAdministrador    {
       IEnumerable<Administrador>  GetAllAdministradores();
       Administrador  AddAdministrador(Administrador administrador);
       Administrador  UpdateAdministrador(Administrador administrador);
       void DeleteAdministrador (int IdAdministrador);
       Administrador  GetAdministrador(int IdAdministrador);
        
       
 }
}