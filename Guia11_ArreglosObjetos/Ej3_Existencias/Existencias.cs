using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_Existencias
{
    class Existencias
    {
        Producto[] productos = new Producto[100];
        public int Cantidad { get;private set; }

        #region busqueda del registro

        public Producto BuscarPorIdx(int idx)
        {
            Producto buscado = null;
            if (idx < Cantidad)
                buscado = productos[idx];            
            return buscado;
        }

        public int BuscarPorCodigo(int codigo)
        {
            int idx = -1;
            for (int n = 0; n < Cantidad && idx == -1; n++)
                if (productos[n].Codigo == codigo)
                    idx = n;
            return idx;
        }

        #endregion

        public int Quitar(int idx)
        {
            int idxd=-1;
            if (idx < Cantidad)
            {
                if (idx > 0) productos[idx] = productos[Cantidad - 1];                    
                Cantidad--;
                idxd = idx;
            }
            return idxd;
        }

        public int Agregar(string nombre, int cantidad) 
        {
            Producto nuevo = new Producto(nombre, cantidad);
            int idx = Cantidad;
            productos[Cantidad++] = nuevo;
            return idx;
        }

        
    }
}
