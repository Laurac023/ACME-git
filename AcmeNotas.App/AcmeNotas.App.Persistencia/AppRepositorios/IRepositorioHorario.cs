using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioHorario  {
       IEnumerable<Horario>  GetAllHorarios();
       Horario  AddHorarios(Horario horario);
       Horario  UpdateHorario(Horario horario);
       void DeleteHorario(int IdHorario);
       Horario GetHorario(int IdHorario);
       
 }
}