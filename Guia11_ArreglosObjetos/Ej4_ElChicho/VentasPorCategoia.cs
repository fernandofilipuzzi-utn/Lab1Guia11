using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4_ElChicho
{
    class VentasPorCategoia
    {
        public string Nombre{get; private set;}
        public int CantVentas { get; private  set; }
        public double MontoVendido { get; private  set; }
        public double MontoDescuentos { get; private set; }
        public double MontoFacturado 
        {
            get 
            {
                return MontoVendido - MontoDescuentos; 
            }
        }
        public double PorcentajeMonto
        {
            get { return MontoFacturado/ MontoVendido*100; } 
        }

        public VentasPorCategoia(string nombre)
        {
            Nombre = nombre;
        }

        public void RegistrarVenta(double montoProducto, bool tieneDescuento)
        {
            CantVentas++;

            MontoVendido += montoProducto;

            double montoConDescuento = montoProducto;
            if (tieneDescuento == true)
                montoConDescuento = montoConDescuento * 5 / 100;

            MontoDescuentos += montoConDescuento;
        }

        public double CalcularPorcentaje(double totalFacturado)
        {
            double porc=01;
            if (totalFacturado > 0)
                porc = MontoFacturado / totalFacturado * 100;
            return porc;
        }
    }
}
