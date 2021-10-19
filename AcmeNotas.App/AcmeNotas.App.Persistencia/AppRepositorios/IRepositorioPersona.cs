using System.Collections.Generic;
using System.Linq;
using AcmeNotas.App.Dominio;


namespace AcmeNotas.App.Persistencia
{
    public interface IRepositorioPersona
    {
         public List<Persona> consultarTodos();

         public int guardarPersona();

         public void eliminarPersona(int Id);

         public void actualizarPersona(Persona persona);
         Persona  GetPersona(int  IdPersona); 
    }
}