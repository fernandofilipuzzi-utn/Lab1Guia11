using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej5_SistemaPeaje
{
    class Program
    {
        static void IngresoDia(Peaje peaje)
        {
            Console.Clear();

            Console.WriteLine("\t\tIngrese el número de día y luego la cantidad de vehículos\n");
            int dia=Convert.ToInt32(Console.ReadLine());
            int cant = Convert.ToInt32(Console.ReadLine());

            peaje.RegistrarResumenDia(dia,cant);

            Console.WriteLine("\n\nPresione una tecla para volver al menu");
            Console.ReadKey();
        }

        static void MostrarLosDíasQueSuperaronAlPromedio(Peaje peaje)
        {
            Console.Clear();

            Console.WriteLine("\t\tDías que superaron el promedio.\n");


            Console.WriteLine($"Promedio: {peaje.PromCantVehiculosDelMes:f2}");
            Console.Write("Días: ");
            int cant;
            int[] dias = peaje.LosDiasMayoresAlPromedio(out cant);
            if (cant > 0)
            {
                for (int n = 0; n < cant; n++)
                {
                    Console.Write($"{dias[n]}");
                    if (n<cant-1)
                        Console.Write(", ");
                }
            }
            else
            {
                Console.WriteLine("No hubo días que superaron al promedio ingresado");
            }

            Console.WriteLine("\n\nPresione una tecla para volver al menu");
            Console.ReadKey();
        }

        static void MostrarTercioDelMesMayor(Peaje peaje)
        {
            Console.Clear();

            Console.WriteLine("\t\tPeriodo del mes con mayor movimiento: ");
            Console.WriteLine($"Periodo {peaje.TercioDelMesMayor()}");

            Console.WriteLine("\n\nPresione una tecla para volver al menu");
            Console.ReadKey();
        }

        static ConsoleKeyInfo Menu()
        {
            Console.Clear();

            Console.WriteLine("\t\t Sistema de peaje\n");

            Console.WriteLine("1- Registrar día.");
            Console.WriteLine("2- Días que superaron al promedio de vehículos del mes.");
            Console.WriteLine("3- Tercio del mes con mayor movimiento.");
            Console.WriteLine("otro- salida");

            return Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Peaje peaje = new Peaje();

            ConsoleKeyInfo key;
            do
            {
                key = Menu();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            IngresoDia(peaje);                           
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            MostrarLosDíasQueSuperaronAlPromedio(peaje);
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            MostrarTercioDelMesMayor(peaje);                            
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
