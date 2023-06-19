using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej4_ElChicho
{
    class Program
    {
        static void Main(string[] args)
        {
            //prueba de concepto, tambien se puede hacer un menú

            Comercio elChicho = new Comercio("El Chicho");

            #region inicio del periodo
            elChicho.AgregarCategoria("Cine hogareño");
            elChicho.AgregarCategoria("Consola de video juego");
            elChicho.AgregarCategoria("Telefonía");
            elChicho.AgregarCategoria("Informáticos");
            #endregion

            #region registrando ventas
            elChicho.VenderProducto(0, 2343.2, true);
            elChicho.VenderProducto(2, 2343.2, true);
            elChicho.VenderProducto(1, 9000.2, false);
            elChicho.VenderProducto(3, 2343.0, true);
            elChicho.VenderProducto(2, 2303.5, true);
            elChicho.VenderProducto(0, 1143.2, false);
            elChicho.VenderProducto(1, 1003.2, true);
            #endregion


            #region mostrando resumen
            double montoTotalFacturado = elChicho.TotalFacturado;

            Console.WriteLine($"{"Nro.",-10} {"Nombre cat.",-30} " +
                            $" {"Cant. Ven.",10}" +
                            $" {"Monto Prod. $",15}" +
                            $" {"Desc $",15}" +
                            $" {"Facturado $",15}" +
                            $" {"Porc. Fact. %",15}");
            for (int n = 0; n < elChicho.CantCategorias; n++)
            {
                VentasPorCategoia c = elChicho.VerCategoria(n);

                Console.WriteLine($"{n + 1,10} {c.Nombre,-30} " +
                                            $" {c.CantVentas,10}"+
                                            $" {c.MontoVendido,15:f2}"+
                                            $" {c.MontoDescuentos,15:f2}"+
                                            $" {c.MontoFacturado,15:f2}"+
                                            $" {c.CalcularPorcentaje(montoTotalFacturado),15:f2}" );
            }
            Console.WriteLine($"El monto total facturado: {montoTotalFacturado,75:f2} ");

            #endregion

            Console.ReadKey();
        }
    }
}
