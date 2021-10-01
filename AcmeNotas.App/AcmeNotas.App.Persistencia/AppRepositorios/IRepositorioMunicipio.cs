using System.Collections.Generic;
using AcmeNotas.App.Dominio;
namespace AcmeNotas.App.Persistencia
{
public interface IRepositorioMunicipio
  {
      IEnumerable<Municipio>  GetAllMunicipios();
       Municipio   AddMunicipio(Municipio municipio);
       Municipio  UpdateMunicipio(Municipio municipio);
       void DeleteMunicipio (int IdMunicipio);
       Municipio  GetMunicipio(int  IdMunicipio); 
  }
}