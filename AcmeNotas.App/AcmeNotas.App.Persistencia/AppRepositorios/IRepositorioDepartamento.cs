using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
public interface IRepositorioDepartamento
  {
      IEnumerable<Departamento>  GetAllDepartamentos();
       Departamento   AddDepartamento(Departamento departamento);
       Departamento  UpdateDepartamento(Departamento departamento);
       void DeleteDepartamento (int IdDepartamento);
       Departamento  GetDepartamento(int  IdDepartamento); 

         }
}