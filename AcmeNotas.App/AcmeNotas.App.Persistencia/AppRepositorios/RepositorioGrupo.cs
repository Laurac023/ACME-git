using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia
{
    public class RepositorioGrupo : IRepositorioGrupo
    {
        private readonly Conexion _appContext;

        public RepositorioGrupo(Conexion appContext)
        {
            _appContext = appContext;
        }
       Grupo IRepositorioGrupo.AddGrupos(Grupo grupo)
       {
          var GrupoAdicionado =  _appContext.Grupos.Add(grupo);
            _appContext.SaveChanges();
             return GrupoAdicionado.Entity; 
       }
      public void DeleteGrupo(int IdGrupo) 
      {
          var GrupoEncontrado= _appContext.Grupos.FirstOrDefault(p =>p.GrupoId==IdGrupo);
         if (GrupoEncontrado ==null)
         return;
         _appContext.Grupos.Remove(GrupoEncontrado);
         _appContext.SaveChanges();
      }
     public IEnumerable <Grupo> GetAllGrupos()
     {
         return _appContext.Grupos;
     }
     public Grupo GetGrupo(int IdGrupo)
     {
         return _appContext.Grupos.FirstOrDefault(p => p.GrupoId == IdGrupo) ;
         
     }
     public Grupo UpdateGrupo(Grupo grupo)
     {
        var GrupoEncontrado= _appContext.Grupos.FirstOrDefault(p =>p.GrupoId==grupo.GrupoId );    
         if (GrupoEncontrado!=null) 
         {
             
             GrupoEncontrado.Ciclo =grupo.Ciclo;
             GrupoEncontrado.Formador = grupo.Formador;
             GrupoEncontrado.GrupoId = grupo.GrupoId;
             GrupoEncontrado.Tutor = grupo.Tutor;
             GrupoEncontrado.Horario = grupo.Horario;
           _appContext.SaveChanges();
       
         }
         return GrupoEncontrado;

     }
    }
}