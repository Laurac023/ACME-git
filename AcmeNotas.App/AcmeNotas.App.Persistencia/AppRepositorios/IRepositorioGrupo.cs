using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioGrupo  {
       IEnumerable<Grupo>  GetAllGrupos();
       Grupo  AddGrupos(Grupo grupo);
       Grupo  UpdateGrupo(Grupo grupo);
       void DeleteGrupo(int IdGrupo);
       Grupo GetGrupo(int IdGrupo);
       
 }
}
