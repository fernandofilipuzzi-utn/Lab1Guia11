using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1_Encuesta
{
    class Program
    {
        static int Menu()
        {
            Console.Clear();

            Console.WriteLine("\t\tSecretaría de transporte de su magestad!");

            Console.WriteLine("\tEncuesta sobre el uso de medios de transporte urbano.\n");

            Console.WriteLine("1- Registrar encuesta");
            Console.WriteLine("2- Imprimir Resultados");
            Console.WriteLine("3- Imprimir Listado contactables");
            Console.WriteLine("Otro- Cerrar");

            return Convert.ToInt32(Console.ReadLine());
        }

        static bool Consulta(string msg)
        {
            bool resultado = false;

            Console.WriteLine(msg);
            ConsoleKeyInfo key = Console.ReadKey();
            char respuesta = Char.ToUpper(key.KeyChar);
            Console.WriteLine("\n");

            if (respuesta == 'S')
            {
                resultado = true;
            }
            else if (respuesta == 'N')
            {
                resultado = false;
            }
            else
            {
                Console.WriteLine("Respuesta inválida.");
            }
            return resultado;
        }

        static void RegistroDeEncuesta(ProcesoEncuestas proceso)
        {
            Console.Clear();

            Encuesta nuevo = new Encuesta();

            Console.WriteLine("Modo de transporte habitual");

            nuevo.UsaBicicleta = Consulta("¿Usa bicleta?: S/N");
            nuevo.UsaAuto = Consulta("¿Usa Automóvil?: S/N");
            nuevo.UsaTransportePublico = Consulta("¿Usa Transporte público?: S/N");

            Console.WriteLine("¿Cuál es la distancia aproximada a su destino de trabajo/estudio en km? (ej:1,5)\n");
            nuevo.DistanciaASuDestino = Convert.ToDouble(Console.ReadLine());

            bool puedeSerContactado = Consulta("¿Puede ser contactado?: S/N");
            if (puedeSerContactado == true)
            {
                Console.Write("Email: ");
                nuevo.Email = Console.ReadLine();
                Console.Write("\n");
            }

            proceso.RegistrarEncuesta(nuevo, puedeSerContactado);

            Console.WriteLine("\nEncuesta procesada!");

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void Informe(ProcesoEncuestas proceso)
        {
            Console.Clear();

            Console.WriteLine("\t\t Informe de resultados \n");
            Console.WriteLine("Modo de transporte habitual\n");

            Console.WriteLine($"\t{"Bicicleta:",-20}  {proceso.PorcBicleta,10:f2}%");
            Console.WriteLine($"\t{"Automóvil:",-20}  {proceso.PorcAuto,10:f2}%");
            Console.WriteLine($"\t{"Transporte público:",-20}  {proceso.PorcTranspPublico,10:f2}%");

            Console.WriteLine("Presione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void ListadoContactables(ProcesoEncuestas proceso)
        {
            Console.Clear();

            Console.WriteLine("\t\t Informe de encuestados contactables \n");

            proceso.OrdernarContactables();
            Console.WriteLine($"\t{"Email",-30} {"Distancia.",10}");
            for (int n = 0; n < proceso.CantContactables; n++)
            {
                Console.WriteLine($"\t{proceso.VerContactable(n).Email,-30} {proceso.VerContactable(n).DistanciaASuDestino,10:f2}");
            }

            Console.WriteLine("\n\nPresione una tecla para volver al menú principal");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            ProcesoEncuestas proceso = new ProcesoEncuestas();
            /*para prueba
            proceso.RegistrarEncuesta(new Encuesta { Email = "fernando@gmail.com", DistanciaASuDestino = 4 },true);
            proceso.RegistrarEncuesta(new Encuesta { Email = "rafael@gmail.com", DistanciaASuDestino = 3 }, true);
            */
            int op;
            do
            {
                op = Menu();

                switch (op)
                {
                    case 1:
                        {
                            RegistroDeEncuesta(proceso);
                        }
                        break;
                    case 2:
                        {
                            Informe(proceso);
                        }
                        break;
                    case 3:
                        {
                            ListadoContactables(proceso);
                        }
                        break;
                    default:
                        {
                            op = 0;
                        }
                        break;
                }
            } while (op > 0);
        }
    }
}
