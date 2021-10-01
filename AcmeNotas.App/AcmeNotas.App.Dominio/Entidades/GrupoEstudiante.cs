using System;
namespace AcmeNotas.App.Dominio
{
    public class GrupoEstudiante
    {
        public int Id {get;set;}
        public String IdGrupo {get;set;}
        public String IdEstudiante {get;set;} //id del estudiante
        public int CodNotas {get; set;} //Notas -
        
    }
}