using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4_ElChicho
{
    class Comercio
    {
        public string NombreEmpresa { get; private set; }
        public VentasPorCategoia MayorFacturacion
        {
            get 
            {
                //es una forma de calcularlo, podría haberlo hecho cuando ingreso la venta

                VentasPorCategoia mayor = null;

                if (CantCategorias > 0)
                {
                    mayor = categorias[0];

                    for (int n = 1; n < CantCategorias; n++)
                        if (mayor.MontoFacturado < categorias[n].MontoFacturado)
                            mayor = categorias[n];
                }

                return mayor;
            }
        }

        public VentasPorCategoia[] categorias = new VentasPorCategoia[100];
        public int CantCategorias { get; private set; } = 0;

        public double TotalFacturado 
        { 
            get
            {
                double total=0;
                for (int n = 1; n < CantCategorias; n++)
                    total += categorias[n].MontoFacturado;

                return total;
            } 
        }

        public Comercio(string nombre)
        {
            NombreEmpresa = nombre;
        }

        public void AgregarCategoria(string nombre )
        {
            categorias[CantCategorias++] = new VentasPorCategoia(nombre);
        }

        public void VenderProducto(int nroCategoria, double montoProducto, bool tieneDescuento)
        {
            categorias[nroCategoria].RegistrarVenta(montoProducto,tieneDescuento);

        }

        public VentasPorCategoia VerCategoria(int numero)
        {
            return categorias[numero];
        }
    }
}
