using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Concesionaria_2_2
{
    class Program
    {
        static ConsoleKeyInfo  Menu()
        {
            Console.Clear();
            Console.WriteLine("1- Entrar embarque");
            Console.WriteLine("2- Mostrar caja");
            Console.WriteLine("3- Embarque con mayor cantidad de motos");
            Console.WriteLine("4- Listado de embarques ingresados");
            Console.WriteLine("otro- salir");

            return Console.ReadKey();
        }

        static Concesionaria Inicio()
        {
            Concesionaria concesionaria;

            Console.WriteLine("Ingrese el año actual");
            int añoActual = Convert.ToInt32(Console.ReadLine());

            concesionaria = new Concesionaria(añoActual);

            return concesionaria;
        }

        static void IngresoEmbarque(Concesionaria c)
        {
            Console.Clear();

            #region solicitar el número de embarque
            Console.WriteLine("Ingrese el número de embarque");
            int numeroEmbarque = Convert.ToInt32(Console.ReadLine());
            #endregion

            Embarque aIngresar = new Embarque(numeroEmbarque, c.PorcentajeDepreciacion, c.AñoActual);
                            
            #region solicitar el año de fabricación de la moto
            Console.WriteLine("Ingrese Año de fabricación de la moto " +
                                                            "a ingresar (0-corte)");
            int añoFabricacion = Convert.ToInt32(Console.ReadLine());
            #endregion

            //xmoto
            while (añoFabricacion > 0)
            {
                #region solicitar el monto de fabriación
                Console.WriteLine("Ingrese el monto de fabricación");
                double montoFabricacion = Convert.ToDouble(Console.ReadLine());
                #endregion

                aIngresar.RegistrarMoto(añoFabricacion, montoFabricacion);

                #region ingrese año de fabricación
                Console.WriteLine("Ingrese Año de fabricación (0-corte)");
                añoFabricacion = Convert.ToInt32(Console.ReadLine());
                #endregion
            }

            Console.Clear();
            Console.WriteLine("Monto del embarque ingresado: ${0:f2}",
                                                            aIngresar.MontoTotal);

         
            c.IngresarEmbarque(aIngresar);

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarRecaudacion(Concesionaria c)
        {
            Console.Clear();

            Console.WriteLine("Monto de todos los embarques : ${0:f2}", c.ImporteEnEmbarques);
            Console.WriteLine("Cantidad de embarques: {0}", c.CantidadEmbarques);

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarEmbarquePorOrdenDeIngreso(Concesionaria c)
        {
            Console.Clear();

            Console.WriteLine("Ingrese el orden del embarque");
            int idx = Convert.ToInt32(Console.ReadLine());

            Embarque buscado = c.VerEmbarque(idx);

            if (buscado != null)
            {
                Console.WriteLine($"{buscado.Numero,10}{ buscado.CantidadMotos,10}{buscado.MontoTotal,10:f2}");
            }
            else
            {
                Console.WriteLine("No existe el embarque");
            }

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Concesionaria c = Inicio();

            ConsoleKeyInfo key;
            do
            {
                key=Menu();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            IngresoEmbarque(c);
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            MostrarRecaudacion(c);
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            MostrarEmbarquePorOrdenDeIngreso(c);
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {//
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