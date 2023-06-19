using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Concesionaria_2_2
{
    class Embarque
    {
        double porcDepreciacionUsado;
        int añoEvaluacion;
        public int Numero { get; private set; }
        public int CantidadMotos { get; private set; }
        public double MontoTotal { get; private set; }

        public Embarque(int numero, double porcDepreciacion, int añoEvaluacion)
        {
            Numero = numero;
            porcDepreciacionUsado = porcDepreciacion;
            this.añoEvaluacion = añoEvaluacion;
        }

        public void RegistrarMoto(int añoFabricacion, double montoFabricacion)
        {
            double montoActual = montoFabricacion * Math.Pow(1 - porcDepreciacionUsado,
                                                               añoEvaluacion - añoFabricacion);

            MontoTotal += montoActual;
            CantidadMotos++;
        }
    }
}
