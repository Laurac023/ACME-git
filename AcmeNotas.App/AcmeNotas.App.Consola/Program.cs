using System;
using System.Diagnostics;
using AcmeNotas.App.Dominio;
using AcmeNotas.App.Persistencia;

namespace AcmeNotas.App.Consola
{
        class Program 
    {
        private static IRepositorioAdministrador _repoAdministrador = new RepositorioAdministrador(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! EF");
            // AddAdministrador();
            BuscarAdministrador(1);
        }
        private  static void AddAdministrador()
        {
            var administrador = new Administrador{
                Nombres= "Jose Antonio",
                Apellidos ="Aguilar",
                Cedula ="",
                CorreoElectronico ="notiene@notiene.com",
                Usuario = "Acme",
                Password= "Dale"
            };
            _repoAdministrador.AddAdministrador(administrador);

        }
        private static void BuscarAdministrador(int IdAdministrador)
        {
            var administrador = _repoAdministrador.GetAdministrador(IdAdministrador);
            Console.WriteLine(administrador.Nombres+ " "+ administrador.Apellidos );


        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
