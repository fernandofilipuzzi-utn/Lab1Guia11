using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej6_Infracciones_2_1_c
{
    class Infraccion
    {
        
        public int Codigo { get; private set; }
        public string Descripcion { get; private set; }
        public int Uds { get; private set; }
    
        public Infraccion(int codigo, string descr,  int uds) 
        {
            Codigo = codigo;
            Descripcion = descr;
            Uds = uds;
        }

        public double CalcularMontoInfraccion(double baseUsada)
        {
            return Uds * baseUsada;
        }
    }
}
