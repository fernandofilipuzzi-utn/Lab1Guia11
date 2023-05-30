using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Existencias
{
    class Program
    {
        static Existencias es = new Existencias();

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            ConsoleKeyInfo key;
            do 
            {
                Console.Clear();
                Console.WriteLine("1- Agregar Existencia");
                Console.WriteLine("2- Quitar Existencia");
                Console.WriteLine("3- Consultar Existencia");
                Console.WriteLine("4- Quitar un producto de la lista");
                Console.WriteLine("4- Listar productos");
                Console.WriteLine("Otro- Salir");

                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            #region agregar existencia
                            Console.Clear();

                            Console.WriteLine("\t\tActualizar existencias\n");
                            Console.Write("Ingrese el código del producto: ");
                            int codigo = Convert.ToInt32(Console.ReadLine());

                            int idx = es.BuscarPorCodigo(codigo);
                            if (idx < 0)
                            {
                                Console.Write("\n\nEl producto no existe - ingrese el nombre para agregarlo: ");
                                string nombre = Console.ReadLine();
                                idx = es.Agregar(nombre, 0);
                            }
                            Producto selected = es.BuscarPorIdx(idx);

                            Console.WriteLine("\n\nActualmente el producto {0} tiene: {0} unidades",
                                                    selected.Nombre, selected.Cantidad);
                            Console.Write("Ingrese la cantidad a agregar (0 para cancelar): ");
                            int cantidad = Convert.ToInt32(Console.ReadLine());
                            if (cantidad > 0)
                                selected.AgregarCantidad(cantidad);

                            Console.WriteLine("\n\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            #endregion
                        }
                        break;

                   
                    case ConsoleKey.D2:
                        {
                            #region  Código para consultar existencia
                            Console.Clear();

                            Console.WriteLine("\t\tExtraer existencias\n");
                            Console.Write("Ingrese el código del producto: ");
                            int codigo = Convert.ToInt32(Console.ReadLine());

                            int idx = es.BuscarPorCodigo(codigo);
                            if (idx < 0)
                            {
                                Console.Write("\n\nEl producto no existe");
                            }
                            else
                            {
                                Producto selected = es.BuscarPorIdx(idx);
                                Console.WriteLine("\n\nActualmente el producto {0} tiene: {0} unidades",
                                                    selected.Nombre, selected.Cantidad);

                                Console.Write("Ingrese la cantidad a extraer (0 para cancelar): ");
                                int cantidad = Convert.ToInt32(Console.ReadLine());
                                if (cantidad > 0)
                                    selected.ExtraerCantidad(cantidad);

                            }

                            Console.WriteLine("\n\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            #endregion
                        }
                        break;

                    case ConsoleKey.D3:
                        {
                            #region  Código para consultar existencia
                            Console.Clear();

                            Console.WriteLine("\t\tConsulta de existencias\n");
                            Console.Write("Ingrese el código del producto: ");
                            int codigo = Convert.ToInt32(Console.ReadLine());

                            int idx = es.BuscarPorCodigo(codigo);
                            if (idx < 0)
                            {
                                Console.Write("\n\nEl producto no existe");
                            }
                            else
                            {
                                Producto selected = es.BuscarPorIdx(idx);
                                Console.WriteLine("\n\nActualmente el producto {0} tiene: {0} unidades",
                                                    selected.Nombre, selected.Cantidad);

                            }

                            Console.WriteLine("\n\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            #endregion
                        }
                        break;

                    case ConsoleKey.D4:
                        {
                            #region  Código para listar productos
                            Console.Clear();

                            Console.WriteLine("\n\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            #endregion
                        }
                        break;

                    case ConsoleKey.D5:
                        {
                            #region  Listar productos
                            Console.Clear();

                            Console.WriteLine("\n\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            #endregion
                        }
                        break;

                    default:
                        // Salir del programa
                        key = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                        break;
                }


            } while (key.KeyChar != '0');
            Console.ReadKey();
        }
    }
}
