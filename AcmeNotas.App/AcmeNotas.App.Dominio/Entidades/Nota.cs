using System;
namespace AcmeNotas.App.Dominio
{
    public class Nota
    {
        public int Id {get; set;}
        public Estudiante estudiante {get; set;}
        public double Nota1 {get; set;}
        public double Nota2 {get; set;}
        public double Nota3 {get; set;}
        public double Nota4 {get; set;}
        public double Nota5 {get; set;}
        public double NotaDefinitiva {get; set;}
    }
}