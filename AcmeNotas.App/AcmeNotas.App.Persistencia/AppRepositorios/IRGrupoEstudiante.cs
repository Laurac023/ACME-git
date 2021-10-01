using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioGrupoEstudiante  {
       IEnumerable<GrupoEstudiante>  GetAllGrupoEstudiantes();
       Tutor  AddGrupoEstudiantes(GrupoEstudiante grupoEstudiante);
       Tutor  UpdateGrupoEstudiante(GrupoEstudiante grupoEstudiante);
       void DeleteGrupoEstudiante(int IdGrupoEstudiante);
       Tutor GetGrupoEstudiante(int IdGrupoEstudiante);
       
 }
}