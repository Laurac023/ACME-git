using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioTutor  {
       IEnumerable<Tutor>  GetAllTutores();
       Tutor  AddTutores(Tutor tutor);
       Tutor  UpdateTutor(Tutor tutor);
       void DeleteTutor(int IdTutor);
       Tutor GetTutor(int IdTutor);
       
 }
}