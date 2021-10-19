using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;



namespace AcmeNotas.App.Persistencia
{
   public class RepositorioDepartamento : IRepositorioDepartamento
   {
        private readonly Conexion _appContext;
        public RepositorioDepartamento (Conexion appContext)
        {
            _appContext = appContext;
        }
            Departamento  IRepositorioDepartamento.AddDepartamento(Departamento departamento)
        {
         var DepartamentoAdicionado =  _appContext.Departamentos.Add(departamento);
            _appContext.SaveChanges();
             return DepartamentoAdicionado.Entity;
        }
        public void DeleteDepartamento(int IdDepartamento)
        {
         var DepartamentoEncontrado= _appContext.Departamentos.FirstOrDefault(p =>p.Id==IdDepartamento);
         if (DepartamentoEncontrado ==null)
         return;
             _appContext.Departamentos.Remove(DepartamentoEncontrado);
             _appContext.SaveChanges();
        }
      public IEnumerable<Departamento> GetAllDepartamentos()
        {
             return _appContext.Departamentos;
        }
    public Departamento  GetDepartamento(int IdDepartamento)
        {
            return _appContext.Departamentos.FirstOrDefault(p =>p.Id==IdDepartamento);
        }
    public Departamento UpdateDepartamento(Departamento departamento)
        {
        var DepartamentoEncontrado= _appContext.Departamentos.FirstOrDefault(p =>p.Id==departamento.Id);    
         if (DepartamentoEncontrado!=null)
         {  
          DepartamentoEncontrado.CodigoDepartamento = departamento.CodigoDepartamento;   
          DepartamentoEncontrado.NombreDepartamento = departamento.NombreDepartamento;
           _appContext.SaveChanges();
         }
         return DepartamentoEncontrado;
       }
    }
}