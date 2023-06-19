using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej6_Infracciones_2_1_c
{
    class Program
    { 
        static void IngresoActa(Sistema sistema)
        {
            Console.Clear();

            Console.WriteLine("Ingrese dni y nombre");
            int dni = Convert.ToInt32(Console.ReadLine());
            string nombre = Console.ReadLine();

            Console.WriteLine("\nTipo de vehículo");
            int tipo = Convert.ToInt32(Console.ReadLine());
            
            Acta nuevo = new Acta(dni, nombre, tipo, sistema.BaseMonetaria );

            Console.WriteLine("Ingrese codigo infraccion(1 a 5 , 0 terminar)");
            int codigo = Convert.ToInt32(Console.ReadLine());
            while (codigo > 0)
            {
                int idx = codigo - 1;
                Infraccion selected = sistema.VerInfraccion(idx);

                nuevo.Agregar(selected);
                
                Console.WriteLine("Ingrese codigo infraccion(1 a 5 , 0 terminar)");
                codigo = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("¿Paga en el lugar?(0/1)");
            int enLugar = Convert.ToInt32(Console.ReadLine());
            nuevo.Finalizar(enLugar==1);
            
            sistema.Agregar(nuevo);

            Console.Clear();
            Console.WriteLine(nuevo.VerTicket());

            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }

        static void ImprimirRecaudacion(Sistema sistema)
        {
            Console.Clear();

            Console.WriteLine("Resumen del día\n");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Recaudación: {0:f2}", sistema.Recaudacion);
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }

        static void ImprimirActaMayorMonto(Sistema sistema)
        {
            Console.Clear();

            Console.WriteLine("Acta con mayor monto pagado\n");
            Console.WriteLine("--------------------------------------------");
            if (sistema.MayorMonto != null)
            {
                Console.WriteLine(sistema.MayorMonto.VerTicket());
            }
            else 
            {
                Console.WriteLine("no hay registro de un acta");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }


        static void ImprimirListadoPagoEnLugar(Sistema sistema)
        {
            Console.Clear();

            Console.WriteLine("Listado de actas que han pagado en el lugar");
            Console.WriteLine("--------------------------------------------");
            for (int n = 0; n < sistema.CantActasRevisar; n++)
            {
                Console.WriteLine(sistema.VerActaRevisar(n).VerTicket());
                Console.WriteLine("--------------------------------------------");
            }
            
            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }

        static ConsoleKeyInfo Menu()
        {
            Console.Clear();
            Console.WriteLine("1- Registrar acta");
            Console.WriteLine("2- Consulta recaudación");
            Console.WriteLine("3- Imprimir acta con mayor monto");
            Console.WriteLine("4- Imprimir listado de pagos en el lugar.");
            Console.WriteLine("otro- salida");
            return Console.ReadKey();
        }

        static Sistema Init()
        {
            Console.Clear();
            Console.WriteLine("Iniciando sistema");
            Console.WriteLine("Ingrese el valor Base (litros nafta/$)");
            double montoBase = Convert.ToDouble(Console.ReadLine());
            return new Sistema(montoBase);
        }

        static void Main(string[] args)
        {
            #region pantalla de configuracion
            Sistema sis = Init();
            #endregion

            ConsoleKeyInfo key;
            do
            {
                key = Menu();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            #region pantalla de carga de acta
                            IngresoActa(sis);
                            #endregion
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            #region pantalla de carga de acta
                            ImprimirRecaudacion(sis);
                            #endregion
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            #region pantalla de acta con mayor monto
                            ImprimirActaMayorMonto(sis);
                            #endregion
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            #region pantalla de actas que pagaron en el lugar
                            ImprimirListadoPagoEnLugar(sis);
                            #endregion
                        }
                        break;
                    default:
                        {
                            key = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                        }
                        break;
                }
            } while (key.Key != ConsoleKey.D0);
        }
    }
}
