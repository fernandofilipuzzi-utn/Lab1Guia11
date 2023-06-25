using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej7_Radar
{
    class ControlRadar
    {
        Vehiculo[] infracciones;
        public int CantidadVehiculo { get; private set; }

        public ControlRadar()
        {
            infracciones= new Vehiculo[100];
            CantidadVehiculo=0;
        }
        public Vehiculo AgregarControl(string patente, double velocidad, bool esOficial)
        {
            Vehiculo nuevo = new Vehiculo(patente, velocidad,esOficial);

            //la responsabilidad de verificar la infracción la tiene
            //la entidad vehiculo. no tiene el vehiculo el sentido visto desde el 
            //conductor, sino desde el punto de vista del oficial de transito
            if ( nuevo.VerificarVelocidadInfraccion() == true)
            {
                infracciones[CantidadVehiculo++] = nuevo;
            }
            return nuevo;
        }

        public Vehiculo VerVehiculosInfractores(int idx)
        {
            Vehiculo buscado = null;

            if(idx>=0 && idx<CantidadVehiculo)
                buscado= infracciones[idx];

            return buscado;
        }

        public Vehiculo BuscarPorPatente(string patente)
        {
            Vehiculo buscado = null;
            int c, n, m;

            n = 0;
            m = CantidadVehiculo;
            while (buscado == null && m > 0 && n<CantidadVehiculo)
            {
                c = (n + m) / 2;
                if (infracciones[c].Patente.CompareTo(patente) == 0)
                {
                    buscado = infracciones[c];
                }
                else if (infracciones[c].Patente.CompareTo( patente )<0)///esta a la derecha
                {
                    n = c + 1; 
                }
                else if (infracciones[c].Patente.CompareTo(patente) > 0)///esta a la izquierda
                {
                    m = c - 1;
                }
            }

            return buscado;
        }

        public void Ordenar()
        {
            Vehiculo aux = null;

            for (int n = 0; n < CantidadVehiculo - 1; n++)
            {
                for (int m = n + 1; m < CantidadVehiculo; m++)
                {
                    if (infracciones[n].Patente.CompareTo(infracciones[m].Patente) > 0)
                    {
                        aux = infracciones[n];
                        infracciones[n] = infracciones[m];
                        infracciones[m] = aux;
                    }
                }
            }
        }
    }
}
