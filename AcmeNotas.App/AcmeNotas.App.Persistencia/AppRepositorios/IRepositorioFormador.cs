using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
    public interface  IRepositorioFormador   {
       IEnumerable<Formador>  GetAllFormadores();
       Formador  AddFormadores(Formador formador);
       Formador  UpdateFormador(Formador formador);
       void DeleteFormador(int IdFormador);
       Formador GetFormador(int IdFormador);
       
 }
}