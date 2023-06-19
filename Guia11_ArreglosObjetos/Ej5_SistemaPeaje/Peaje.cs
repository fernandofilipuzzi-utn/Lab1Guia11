using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5_SistemaPeaje
{
    class Peaje
    {
        int[] Cantidades;

        public Peaje()
        {
            Cantidades = new int[31];
            for (int n = 0; n < 31; n++)
                Cantidades[n] = 0;
        }

        public double PromCantVehiculosDelMes
        {
            get 
            {
                int acum = 0;
                for (int n = 0; n < 31; n++)
                    acum += Cantidades[n];
                return acum / 31d;
            }
        }

        public void RegistrarResumenDia(int dia, int cantidadVehiculos)
        {
            Cantidades[dia-1] = cantidadVehiculos;//indice=dia-1!
        }

        public int[] LosDiasMayoresAlPromedio(out int cant)
        {
            cant = 0;
            double promedio = PromCantVehiculosDelMes;

            int[] dias = new int[31];
            for (int n = 0; n < 31; n++)
            {
                if (Cantidades[n] > promedio)
                {
                    dias[cant++] = n + 1;//día!
                }
            }

            return dias;
        }

        public int TercioDelMesMayor()
        {
            int[] periodos = new int[] { 0,0,0};

            #region determino la cantidad de vehículos por cada periodo
            for (int n = 0; n < 31; n++)
            {
                if (n < 10) periodos[0] += Cantidades[n];
                else if (n < 20) periodos[1] += Cantidades[n];
                else periodos[2] += Cantidades[n];                
            }
            #endregion

            #region busqueda del mayor indice
            int m = 0;
            for (int n = 1; n < 3; n++)
            {
                if (periodos[n] > periodos[m]) m = n;
            }
            #endregion

            int mayor =m+ 1;//mayor periodo

            //no está definido si son todos ceros o el empate.

            return mayor;
        }
    }
}
