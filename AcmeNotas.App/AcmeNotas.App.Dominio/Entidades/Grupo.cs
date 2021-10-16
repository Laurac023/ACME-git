using System;

namespace AcmeNotas.App.Dominio
{
    public class Grupo
    {
        public int Id{get; set;}

        public Persona Formador{get; set;}

        public Persona Tutor{get; set;}

        public string CodigoGrupo {get; set;}

        public Ciclo Ciclo {get; set;}

        public Horario Horario {get;set;}
        
    }
}


/*namespace AcmeNotas.App.Dominio
{
    public class Grupo
    {
        /*public int Id {get;set;}
        public String CodigoGrupo{get; set;}
        public String Ciclos {get; set;}
        public String CodigoFormador {get; set;}
        public String CodigoTutor {get; set;}
        public int CodHorario {get;set;}

        //public String Estudiantes {get; set;}
        //horario
    }

}*/