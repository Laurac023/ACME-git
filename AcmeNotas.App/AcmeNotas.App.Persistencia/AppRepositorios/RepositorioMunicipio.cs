using System.Collections.Generic;
using AcmeNotas.App.Dominio;
using System.Linq;



namespace AcmeNotas.App.Persistencia
{
   public class RepositorioMunicipio : IRepositorioMunicipio
   {
        private readonly Conexion _appContext;
        public RepositorioMunicipio (Conexion appContext)
        {
            _appContext = appContext;
        }
            Municipio  IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        {
         var MunicipioAdicionado =  _appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
             return MunicipioAdicionado.Entity;
        }
        public void DeleteMunicipio(int IdMunicipio)
        {
         var MunicipioEncontrado= _appContext.Municipios.FirstOrDefault(p =>p.Id==IdMunicipio);
         if (MunicipioEncontrado ==null)
         return;
             _appContext.Municipios.Remove(MunicipioEncontrado);
             _appContext.SaveChanges();
        }
      public IEnumerable<Municipio> GetAllMunicipios()
        {
             return _appContext.Municipios;
        }
    public Municipio  GetMunicipio(int IdMunicipio)
        {
            return _appContext.Municipios.FirstOrDefault(p =>p.Id==IdMunicipio);
        }
    public Municipio UpdateMunicipio(Municipio municipio)
        {
        var MunicipioEncontrado= _appContext.Municipios.FirstOrDefault(p =>p.Id==municipio.Id);    
         if (MunicipioEncontrado!=null)
         {  
          MunicipioEncontrado.Departamento = municipio.Departamento;
          MunicipioEncontrado.CodMunicipio = municipio.CodMunicipio;   
          MunicipioEncontrado.NombreMunicipio = municipio.NombreMunicipio;
           _appContext.SaveChanges();
         }
         return MunicipioEncontrado;
       }
       public IEnumerable<Municipio> ListaMunicipiosdeunDepto(string CodigoDepartamento)
       {
           return _appContext.Municipios.Where(p =>p.Departamento.CodigoDepartamento==CodigoDepartamento).ToList();
       }
   }
}