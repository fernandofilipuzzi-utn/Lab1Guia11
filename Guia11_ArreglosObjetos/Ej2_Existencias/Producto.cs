using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Existencias
{
    class Producto
    {
        static int GenNum;
        public int Codigo { get;private set; }
        public int Cantidad { get; private set; }
        public string Nombre { get;private  set; }

        public Producto(string nombre, int cant) {
            Nombre = nombre;
            Cantidad = cant;
        }

        public int AgregarCantidad(int reposicion) {
            return Cantidad += reposicion;
        }

        public int QuitarCantidad(int extraccion) {
            return Cantidad -= extraccion;
        }
    }
}
