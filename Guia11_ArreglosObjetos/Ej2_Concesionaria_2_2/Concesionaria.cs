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

        public Concesionaria(int añoActual)
        {
            embarques = new Embarque[100];

            CantidadEmbarques = 0;
            ImporteEnEmbarques = 0;
            this.AñoActual = añoActual;
        }

        public void IngresarEmbarque(Embarque nuevo)
        {
            embarques[CantidadEmbarques++] = nuevo;
            ImporteEnEmbarques += nuevo.MontoTotal;
        }

        public Embarque VerEmbarque(int idx) 
        {
            return embarques[idx];
        }
    }
}
