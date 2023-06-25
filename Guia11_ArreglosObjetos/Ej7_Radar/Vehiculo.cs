using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej7_Radar
{
    class Vehiculo
    {
        public string Patente { get; private set; }
        public double Velocidad { get; private set; }
        public bool EsOficial { get; private set; }

        public Vehiculo(string patente, double velocidad, bool esOficial) 
        {
            Patente = patente;
            Velocidad = velocidad;
            EsOficial = esOficial;
        }
        public bool VerificarVelocidadInfraccion()
        {
            //se tienen que cumplir dos condiciones
            //1- que este fuera del rango de velocidades permitido
            //2- que no sea oficial, 
            //no tienen sentido que a una ambulancia o a un patrullero le haga una infracción
            return (Velocidad < 50 || Velocidad > 90)&& EsOficial == false;
        }
    }
}
