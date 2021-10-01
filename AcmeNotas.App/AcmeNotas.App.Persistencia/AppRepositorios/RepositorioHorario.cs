using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia
{
    public class RepositorioHorario : IRepositorioHorario    
    {
        private readonly AppContext _appContext;
        public RepositorioHorario(AppContext appContext )
        {
              _appContext = appContext;
        }      
      Horario  IRepositorioHorario.AddHorarios(Horario horario)
        {
         var HorarioAdicionado =  _appContext.Horarios.Add(horario);
            _appContext.SaveChanges();
             return HorarioAdicionado.Entity;
        }
        public void DeleteHorario(int IdHorario)
        {
         var HorarioEncontrado= _appContext.Horarios.FirstOrDefault(p =>p.Id==IdHorario);
         if (HorarioEncontrado ==null)
         return;
             _appContext.Horarios.Remove(HorarioEncontrado);
             _appContext.SaveChanges();
        }
      public IEnumerable<Horario> GetAllHorarios()
        {
             return _appContext.Horarios;
        }
    public Horario GetHorario(int IdHorario)
        {
            return _appContext.Horarios.FirstOrDefault(p =>p.Id==IdHorario);
        }
    public Horario UpdateHorario(Horario horario)
        {
        var HorarioEncontrado= _appContext.Horarios.FirstOrDefault(p =>p.Id==horario.Id);    
         if (HorarioEncontrado!=null)
         {
          HorarioEncontrado.Dia1 = horario.Dia1;
          HorarioEncontrado.HoraInicio1 = horario.HoraInicio1;
          HorarioEncontrado.HoraFinal1= horario.HoraFinal1;
          HorarioEncontrado.Dia2 = horario.Dia2;
          HorarioEncontrado.HoraInicio2 = horario.HoraInicio2;
          HorarioEncontrado.HoraFinal2= horario.HoraFinal2;
          HorarioEncontrado.Dia3 = horario.Dia3;
          HorarioEncontrado.HoraInicio3 = horario.HoraInicio3;
          HorarioEncontrado.HoraFinal3= horario.HoraFinal3;
         
           _appContext.SaveChanges();
         }
         return HorarioEncontrado;
    }
 }
}