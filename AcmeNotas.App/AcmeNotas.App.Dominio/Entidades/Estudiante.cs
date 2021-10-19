using System;

namespace AcmeNotas.App.Dominio
{
    public class Estudiante : Persona
    {
        public Grupo Grupo {get; set;}
        public string CodigoEstudiante {get; set;}
    }
}