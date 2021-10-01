using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
   public interface IRepositorioNota
   {
       IEnumerable<Nota>  GetAllNotas();
       Nota   AddNota(Nota nota);
       Nota  UpdateNota(Nota nota);
       void DeleteNota (int IdNota);
       Nota  GetNota(int  IdNota); 
   } 
}