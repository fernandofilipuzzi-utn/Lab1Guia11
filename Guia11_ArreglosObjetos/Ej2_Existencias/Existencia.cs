using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2_Existencias
{
    class Existencia
    {
        Producto[] productos = new Producto[100];
        public int Cantidad { get;private set; }

        public Producto Consultar(int codigo) {
            return productos[codigo];
        }

        public Producto Agregar(string nombre, int cantidad) 
        {
            Producto nuevo = new Producto(nombre, cantidad);
            productos[Cantidad++] = nuevo;
            return nuevo;
        }

        public Producto Quitar(int codigo) {
            Producto quitado = productos[codigo];
            productos[codigo] = productos[Cantidad - 1];
            return quitado;
        }
    }
}
