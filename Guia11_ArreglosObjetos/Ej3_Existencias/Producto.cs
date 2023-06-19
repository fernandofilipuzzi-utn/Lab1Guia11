using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_Existencias
{
    class Producto
    {
        static int GenNum=1;
        public int Codigo { get;private set; }
        public int Cantidad { get; private set; }
        public string Nombre { get;private  set; }

        public Producto(string nombre, int cant) 
        {
            Codigo += GenNum++;
            Nombre = nombre;
            Cantidad = cant;
        }

        public int AgregarCantidad(int reposicion) 
        {
            return Cantidad += reposicion;
        }

        public int ExtraerCantidad(int extraccion) 
        {
            int actual = Cantidad - extraccion;
            if (actual >= 0)
                Cantidad -= extraccion;
            return actual;
        }
    }
}
