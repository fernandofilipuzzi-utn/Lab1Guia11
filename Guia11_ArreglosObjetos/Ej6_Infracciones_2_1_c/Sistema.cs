using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej6_Infracciones_2_1_c
{
    class Sistema
    {
        
        Infraccion[] infracciones = new Infraccion[5];
        public int CantInfraccion { get; private set; }

        Acta[] actasARevisar = new Acta[100];
        public int CantActasRevisar { get; private set; }

        public double BaseMonetaria { get; set; }
        public double Recaudacion { get; private set; }
        public Acta MayorMonto { get; private set; }

        int nroActa;
        
        public Sistema(double baseMonetaria)
        {
            this.BaseMonetaria = baseMonetaria;
            this.Recaudacion = 0;
            this.nroActa=0;

            #region creando el catalogo
            infracciones[0] = new Infraccion(1, "Sin luces bajas, ley 25….", 25);
            infracciones[1] = new Infraccion(2, "Falta de Matafuego, ley 2…", 30);
            infracciones[2] = new Infraccion(3, "Sobrevelocidad", 100);
            infracciones[3] = new Infraccion(4, "Falta de cinturón de seguridad (>2 ejes) o falta de casco (1 eje)", 85);
            infracciones[4] = new Infraccion(5, "Falta de respeto A la autoridad", 1500);
            CantInfraccion = 5;
            #endregion
        }

        public void Agregar(Acta nuevo)
        {
            if (nroActa == 0)
            {
                MayorMonto = nuevo;
            }
            else if (nuevo.TotalAPagar>MayorMonto.TotalAPagar)
            {
                MayorMonto = nuevo;
            }
            nroActa++;

            Recaudacion += nuevo.TotalAPagar;

            if (nuevo.PagoEnLugar==true)
            {
                actasARevisar[CantActasRevisar++] = nuevo;
            }
        }

        public Infraccion VerInfraccion(int idx)
        {
            Infraccion buscado = null;
            if (idx >= 0 && idx<5)
                buscado= infracciones[idx];
            return buscado;
        }

        public void OrdenarActasPorMonto()
        {
            for (int n = 0; n < CantActasRevisar - 1; n++)
            {
                for (int m = n+1; m < CantActasRevisar; m++)
                {
                    if (actasARevisar[n].TotalAPagar > actasARevisar[m].TotalAPagar)
                    {
                        Acta aux = actasARevisar[n];
                        actasARevisar[n] = actasARevisar[m];
                        actasARevisar[m] = aux;
                    }
                }
            }
        }

        public Acta VerActaRevisar(int idx)
        {
            Acta buscado = null;
            if(idx>=0 && idx<CantActasRevisar)
                buscado= actasARevisar[idx];

            return buscado;
        }
    }
}
