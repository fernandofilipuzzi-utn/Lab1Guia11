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

            Console.WriteLine("\t\t Mi Concesionaria\n");

            Console.WriteLine("1- Entrar embarque");
            Console.WriteLine("2- Mostrar caja");
            Console.WriteLine("3- Embarque con mayor cantidad de motos");
            Console.WriteLine("4- Ver datos por número de embarque");
            Console.WriteLine("5- Listado de embarques ingresados ordenados por monto");
            Console.WriteLine("otro- salir");

            return Console.ReadKey();
        }

        static Concesionaria Inicio()
        {
            Console.Clear();

            Console.WriteLine("\t\t Mi Concesionaria\n");

            Concesionaria concesionaria;
            Console.WriteLine("\tIniciando el sistema.\n");

            Console.WriteLine("Ingrese el año actual");
            int añoActual = Convert.ToInt32(Console.ReadLine());

            concesionaria = new Concesionaria(añoActual);

            return concesionaria;
        }

        static void IngresoEmbarque(Concesionaria c)
        {
            Console.Clear();

            Console.WriteLine("\t\t Ingreso de embarques a concesionaria\n");

            Console.Write("Ingrese el número de embarque: ");
            int numeroEmbarque = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            Embarque aIngresar = new Embarque(numeroEmbarque, c.PorcentajeDepreciacion, c.AñoActual);
                            
            Console.WriteLine("Ingrese Año de fabricación de la moto a ingresar (0-corte): ");
            int añoFabricacion = Convert.ToInt32(Console.ReadLine());

            while (añoFabricacion > 0)
            {
                Console.Write("Ingrese el monto de fabricación: $");
                double montoFabricacion = Convert.ToDouble(Console.ReadLine());
                Console.Write("\n\n");

                aIngresar.RegistrarMoto(añoFabricacion, montoFabricacion);

                Console.WriteLine("Ingrese Año de fabricación (0-corte): ");
                añoFabricacion = Convert.ToInt32(Console.ReadLine());                
            }

            Console.Clear();
            Console.WriteLine("Monto del embarque ingresado: ${0:f2}", aIngresar.MontoTotal);
         
            c.IngresarEmbarque(aIngresar);

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarRecaudacion(Concesionaria c)
        {
            Console.Clear();

            Console.WriteLine("\t\t Informe de resultados\n");

            Console.WriteLine("Monto de todos los embarques : ${0:f2}", c.ImporteEnEmbarques);
            Console.WriteLine("Cantidad de embarques: {0}", c.CantidadEmbarques);
            
            Console.WriteLine("\n\n");

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarEmbarqueMayor(Concesionaria c) 
        {
            Console.Clear();

            Console.WriteLine("\t\tEmbarque con mayor cantidad de motos\n");

            Embarque e = c.MayorCantidadMotos;
            if (e != null)
            {
                Console.WriteLine($"Numero de embarque: {e.Numero}");
                Console.WriteLine($"Promedio de costo por moto: $ {e.PromedioCosto:f2}");
                Console.WriteLine($"Monto Total del embarque: $ {e.MontoTotal}");
            }
            else
            { 
                Console.WriteLine($"No se han registrado embarques.");
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarEmbarquePorNumero(Concesionaria c)
        {
            Console.Clear();

            Console.WriteLine("Ingrese el número del embarque");
            int numero = Convert.ToInt32(Console.ReadLine());

            Embarque buscado = c.VerEmbarquePorNumero(numero);

            Console.WriteLine($"{"Numero",10} {"Cant. de Motos",-20} {"MontoTotal",20}");
            Console.WriteLine("------------------------------------------------------------");
            if (buscado != null)
            {
                Console.WriteLine($"{buscado.Numero,10}{ buscado.CantidadMotos,20}{buscado.MontoTotal,20:f2}");
            }
            else
            {
                Console.WriteLine($"No existe el embarque con  número: {numero}");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void MostrarListadoEmbarquesOrdenado(Concesionaria c)
        {
            Console.Clear();

            Console.WriteLine("\t\tListado de embarques ordenados\n");
            
            if(c.CantidadEmbarques>0)
            {
                Embarque[] e = c.ListaOrdenadaEmbarques();

                Console.WriteLine($"{"Numero",10} {"Cant. de Motos",-20} {"MontoTotal",20}");
                Console.WriteLine("------------------------------------------------------------");
                for (int n=0; n<c.CantidadEmbarques; n++)
                    Console.WriteLine($"{e[n].Numero,10} { e[n].CantidadMotos,20} {e[n].MontoTotal,20:f2}");
            }
            else
            {
                Console.WriteLine($"No existe se han registrados embarques.\n");
            }

            Console.WriteLine("\n\n");

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
                            MostrarEmbarqueMayor(c);
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            MostrarEmbarquePorNumero(c);
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        {
                            MostrarListadoEmbarquesOrdenado(c);
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