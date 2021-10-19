using System;
namespace AcmeNotas.App.Dominio
{
    public class Municipio 
    {   
        public int Id {get;set;}
        public String CodMunicipio {get;set;}
        public String NombreMunicipio {get;set;}
        public Departamento Departamento {get;set;}
    }
    
}
