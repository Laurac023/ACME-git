using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioEstudiante    {
       IEnumerable<Estudiante>  GetAllEstudiantes();
       Estudiante  AddEstudiantes(Estudiante estudiante);
       Estudiante  UpdateEstudiante(Estudiante estudiante);
       void DeleteEstudiante(int IdEstudiante);
       Estudiante GetEstudiante(int IdEstudiante);
        
       
 }
}