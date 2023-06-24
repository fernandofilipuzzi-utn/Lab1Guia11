using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Concesionaria_2_2
{
    class Concesionaria
    {
        public double PorcentajeDepreciacion { get; set; } = 10d / 100;
                      
        public int AñoActual { get;private set; }
        
        public double ImporteEnEmbarques { get; private set; }

        Embarque[] embarques;
        public int CantidadEmbarques { get; private set; }

        public Embarque MayorCantidadMotos { get; private set; }

        public Concesionaria(int añoActual)
        {
            embarques = new Embarque[100];

            CantidadEmbarques = 0;
            ImporteEnEmbarques = 0;
            this.AñoActual = añoActual;
        }

        public void IngresarEmbarque(Embarque nuevo)
        {
            //podría en el getter recorrer el vector y sacarlo ahí tambien
            if (CantidadEmbarques == 0 || nuevo.CantidadMotos>MayorCantidadMotos.CantidadMotos)
                MayorCantidadMotos = nuevo;

            embarques[CantidadEmbarques++] = nuevo;
            ImporteEnEmbarques += nuevo.MontoTotal;
        }

        public Embarque VerEmbarquePorIndice(int idx) 
        {
            Embarque buscado = null;

            if (idx >= 0 && idx < CantidadEmbarques)
                buscado = embarques[idx];

            return buscado;
        }

        public Embarque VerEmbarquePorNumero(int numero)
        {
            Embarque buscado = null;

            int n = 0;
            while (n < CantidadEmbarques && buscado == null)
            {
                if (embarques[n].Numero == numero)
                    buscado = embarques[n];
                n++;
            }

            return buscado;
        }

        public Embarque[] ListaOrdenadaEmbarques()
        {
            return MergeSort(embarques, 0, CantidadEmbarques - 1);
        }

        Embarque[] MergeSort(Embarque[] lista, int inicio, int fin)
        {
            Embarque[] resultado = null;
            if (inicio < fin)
            {
                int centro = (inicio + fin) / 2;
                Embarque[] izq = MergeSort(lista, inicio, centro);
                Embarque[] der = MergeSort(lista, centro + 1, fin);

                resultado = new Embarque[izq.Length + der.Length];

                int n = 0, i = 0, d = 0;
                while (i < izq.Length || d < der.Length)
                {
                    if (d >= der.Length)
                    {
                        resultado[n] = izq[i];
                        i++;
                    }
                    else if (i >= izq.Length)
                    {
                        resultado[n] = der[d];
                        d++;
                    }
                    else if (izq[i].MontoTotal < der[d].MontoTotal)
                    {
                        resultado[n] = izq[i];
                        i++;
                    }
                    else
                    {
                        resultado[n] = der[d];
                        d++;
                    }
                    n++;
                }
            }
            else
            {
                resultado = new Embarque[1];
                resultado[0] = lista[inicio];
            }

            return resultado;
        }
                
    }
}
