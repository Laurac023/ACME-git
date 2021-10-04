using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;
namespace AcmeNotas.App.Persistencia
{
    public class RepositorioNota : IRepositorioNota
    {
        private readonly Conexion _appContext;
        public RepositorioNota (Conexion appContext)
        {
            _appContext = appContext;
        }
        Nota IRepositorioNota.AddNota(Nota nota)
        {
            var NotaAdicionada =  _appContext.Notas.Add(nota);
            _appContext.SaveChanges();
             return NotaAdicionada.Entity;
        }
        public void DeleteNota(int IdNota)
        {
          var NotaEncontrada= _appContext.Notas.FirstOrDefault(p =>p.Id==IdNota);
         if (NotaEncontrada ==null)
         return;
             _appContext.Notas.Remove(NotaEncontrada);
             _appContext.SaveChanges();  
        }
        public IEnumerable<Nota> GetAllNotas()
        {
            return _appContext.Notas;
        }
        public Nota  GetNota(int IdNota)
        {
            return _appContext.Notas.FirstOrDefault(p =>p.Id  ==IdNota);
        }
       public  Nota UpdateNota(Nota nota)
       {
         var NotaEncontrada= _appContext.Notas.FirstOrDefault(p =>p.Id== nota.Id);    
         if (NotaEncontrada!=null)
         {
            NotaEncontrada.Nota1= nota.Nota1;
            NotaEncontrada.Nota2= nota.Nota2;
            NotaEncontrada.Nota3= nota.Nota3;
            NotaEncontrada.Nota4= nota.Nota4;
            NotaEncontrada.Nota5= nota.Nota5;
            

        
         }
         return NotaEncontrada;  
       }
    }
}