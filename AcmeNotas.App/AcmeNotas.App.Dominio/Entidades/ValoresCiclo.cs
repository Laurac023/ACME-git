using System.Collections.Generic;

namespace AcmeNotas.App.Dominio
{
    public class ValoresCiclo
    {
        public static List<double> ConvertirDatosCiclo(Ciclo nombreCiclo)
        {
            switch (nombreCiclo)
            {
                case Ciclo.Ciclo1:
                    return new List<double>() { 0.1, 0.15, 0.15, 0.3, 0.3 };
                case Ciclo.Ciclo2:
                    return new List<double>() { 0.125, 0.125, 0.25, 0.25, 0.25 };
                case Ciclo.Ciclo3:
                    return new List<double>() { 0.2, 0.2, 0.2, 0.2, 0.2 };
                case Ciclo.Ciclo4:
                    return new List<double>() { 0.1, 0.2, 0.2, 0.2, 0.3 };
                default:
                    return null;
            }
        }
    }
}