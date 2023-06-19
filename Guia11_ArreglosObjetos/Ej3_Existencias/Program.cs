using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Existencias
{
    class Program
    {
        #region configuración
        static int width = 75;
        static int high = 22;

        static void Iniciar()
        {
            Console.WindowHeight = high + 5;
            Console.BufferHeight = high + 5;

            Console.WindowWidth = width + 5;
            Console.BufferWidth = width + 5;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        #endregion

        #region utilidades

        static void ImprimirMarco()
        {
            Console.Clear();

            //
            char chr;
            //imprime las líneas horizontales
            for (int n = 5; n <= width; n++)
            {
                if (n == 5)
                    chr = '╔';
                else if (n == 75)
                    chr = '╗';
                else
                    chr = '═'; //no es el igual, es parecido, es un poco más largo.

                Console.SetCursorPosition(n - 1, 2 - 1);
                Console.Write(chr);

                if (n == 5)
                    chr = '╚';
                else if (n == 75)
                    chr = '╝';
                else
                    chr = '═';

                Console.SetCursorPosition(n - 1, high - 1);
                Console.Write(chr);
            }


            for (int n = 2 + 1; n < high; n++)
            {
                Console.CursorTop = n - 1;
                Console.CursorLeft = 5 - 1;
                Console.Write("║");

                Console.CursorTop = n - 1;
                Console.CursorLeft = width - 1;
                Console.Write("║");
            }

            Console.CursorTop = 3;
            Console.CursorLeft = 7;
        }

        static void RetornoMenu()
        {
            Console.CursorLeft = 7;
            Console.WriteLine("Presione una tecla para volver al menú");
            Console.CursorLeft = 9;
            Console.ReadKey();
        }

        #endregion

        #region impresión de las Pantallas.

        static void ImprimirAgregarExistencia(Existencias es)
        {
            Console.CursorLeft = 7;
            Console.WriteLine("\t\tActualizar existencias\n");

            Console.CursorLeft = 7;
            Console.Write("Ingrese el código del producto: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            int idx = es.BuscarPorCodigo(codigo);
            if (idx < 0)                
            {
                Console.Write("\n\n");
                Console.CursorLeft = 7;
                Console.WriteLine("El producto no existe - ingrese el nombre para agregarlo: ");
                string nombre = Console.ReadLine();
                idx = es.Agregar(nombre, 0);
            }
            Producto selected = es.BuscarPorIdx(idx);
            Console.Write("\n\n");
            Console.CursorLeft = 7;
            Console.WriteLine("Actualmente el producto {0} tiene: {0} unidades",
                                    selected.Nombre, selected.Cantidad);

            Console.CursorLeft = 7;
            Console.Write("Ingrese la cantidad a agregar (0 para cancelar): ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            if (cantidad > 0)
                selected.AgregarCantidad(cantidad);
        }

        static void ImprimirExtraerExistencia(Existencias es)
        {

            Console.CursorLeft = 7;
            Console.WriteLine("\t\tExtraer existencias\n");

            Console.CursorLeft = 7;
            Console.Write("Ingrese el código del producto: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            int idx = es.BuscarPorCodigo(codigo);
            if (idx < 0)
            {
                Console.WriteLine("\n\n");
                Console.CursorLeft = 7;
                Console.Write("\n\nEl producto no existe");
            }
            else
            {
                Producto selected = es.BuscarPorIdx(idx);

                Console.WriteLine("\n\n");
                Console.CursorLeft = 7;
                Console.WriteLine("Actualmente el producto {0} tiene: {0} unidades",
                                    selected.Nombre, selected.Cantidad);

                Console.CursorLeft = 7;
                Console.WriteLine("Ingrese la cantidad a extraer (0 para cancelar): ");

                Console.CursorLeft = 7;
                int cantidad = Convert.ToInt32(Console.ReadLine());
                if (cantidad > 0)
                    selected.ExtraerCantidad(cantidad);
            }
        }

        static void ImprimirConsultarExistencia(Existencias es)
        {
            Console.CursorLeft = 7;
            Console.WriteLine("\t\tConsulta de existencias\n");

            Console.CursorLeft = 7;
            Console.Write("Ingrese el código del producto: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            int idx = es.BuscarPorCodigo(codigo);
            if (idx < 0)
            {
                Console.WriteLine("\n\n");
                Console.CursorLeft = 7;
                Console.Write("El producto no existe");
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.CursorLeft = 7;
                Producto selected = es.BuscarPorIdx(idx);
                Console.WriteLine("Actualmente el producto {0} tiene: {1} unidades",
                                    selected.Nombre, selected.Cantidad);
            }
        }

        static void ImprimirQuitarProducto(Existencias es)
        {
            Console.CursorLeft = 7;
            Console.WriteLine("\t\tConsulta de existencias\n");

            Console.CursorLeft = 7;
            Console.Write("Ingrese el código del producto: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            int idx = es.BuscarPorCodigo(codigo);
            if (idx < 0)
            {
                Console.WriteLine("\n\n");
                Console.CursorLeft = 7;
                Console.Write("El producto no existe");
            }
            else
            {
                idx = es.Quitar(idx);
                if (idx < 0)
                {
                    Console.WriteLine("\n\n");
                    Console.CursorLeft = 7;
                    Console.Write("El producto no fue quitado");
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.CursorLeft = 7;
                    Console.Write("El producto fue quitado");
                }
            }
        }

        static void ImprimirListado(Existencias es)
        {
            
            Console.CursorLeft = 7;
            Console.WriteLine("{0,-10} │ {1,-25} │ {2,10}", "Cód.", "Nombre", "Cant.");
            Console.CursorLeft = 7;
            Console.WriteLine("───────────┼───────────────────────────┼───────────");
            for (int n = 0; n < es.Cantidad; n++)
            {
                Producto p = es.BuscarPorIdx(n);
                Console.CursorLeft = 7;
                Console.WriteLine("{0,10} │ {1,-25} │ {2,-10}", p.Codigo, p.Nombre, p.Cantidad);
            }
            Console.CursorLeft = 7;
            Console.WriteLine("\n\n");
        }

        static ConsoleKeyInfo ImprimirMenu()
        {
            ConsoleKeyInfo key;

            Console.CursorLeft = 7;
            Console.WriteLine("1- Agregar Existencia");
            Console.CursorLeft = 7;
            Console.WriteLine("2- Quitar Existencia");
            Console.CursorLeft = 7;
            Console.WriteLine("3- Consultar Existencia");
            Console.CursorLeft = 7;
            Console.WriteLine("4- Quitar un producto de la lista");
            Console.CursorLeft = 7;
            Console.WriteLine("5- Listar productos");
            Console.CursorLeft = 7;
            Console.WriteLine("Otro- Salir");

            Console.CursorLeft = 7;
            key = Console.ReadKey();
            return key;
        }

        #endregion

        static void Main(string[] args)
        {
            Iniciar();
                      
            Existencias es = new Existencias();
                      
            ConsoleKeyInfo key;
            do 
            {
                #region pantalla del menú
                ImprimirMarco();
                key =ImprimirMenu();
                #endregion

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            #region agregar existencia
                            ImprimirMarco();

                            ImprimirAgregarExistencia(es);

                            RetornoMenu();
                            #endregion
                        }
                        break;
                                           
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            #region  Código para consultar existencia
                            ImprimirMarco();

                            ImprimirExtraerExistencia(es);

                            RetornoMenu();
                            #endregion
                        }
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            #region  Código para consultar existencia
                            ImprimirMarco();

                            ImprimirConsultarExistencia(es);

                            RetornoMenu();
                            #endregion
                        }
                        break;

                    case ConsoleKey.D4: 
                    case ConsoleKey.NumPad4:
                        {
                            #region  Quitar Producto
                            ImprimirMarco();

                            ImprimirQuitarProducto(es);

                            RetornoMenu();
                            #endregion
                        }
                        break;

                    case ConsoleKey.D5: 
                    case ConsoleKey.NumPad5:
                        {
                            #region  Listar productos
                            ImprimirMarco();

                            ImprimirListado(es);

                            RetornoMenu();
                            #endregion
                        }
                        break;

                    default:
                        {
                            key = new ConsoleKeyInfo('0', ConsoleKey.D0, false, false, false);
                        }
                        break;
                }


            } while (key.KeyChar != '0');
            Console.ReadKey();
        }
    }
}
