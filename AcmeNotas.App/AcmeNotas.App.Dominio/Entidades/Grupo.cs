using System;

namespace AcmeNotas.App.Dominio
{
    public class Grupo
    {
        public int GrupoId{get; set;}

        public Persona Formador{get; set;}

        public Persona Tutor{get; set;}

        public string CodigoGrupo {get; set;}

        public Ciclo Ciclo {get; set;}

        public Horario Horario {get;set;}
        
    }
}

