using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
public interface IRepositorioRol

{
     IEnumerable<Rol>  GetAllRoles();
       Rol   AddRol(Rol rol);
       Rol  UpdateRol(Rol rol);
       void DeleteRol (int IdRol);
       Rol  GetRol(int  IdRol); 
}

}
