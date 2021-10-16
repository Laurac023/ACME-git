using System;

namespace AcmeNotas.App.Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        public String Cedula { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String CorreoElectronico { get; set; }
        public String Departamento { get; set; }
        public Municipio Municipio { get; set; }
        public Rol RolPersona {get; set;}
        public String Usuario {get;set;}
        public String Password {get;set;}
        public Boolean PrimerRegistro {get;set;}
     
    }
}