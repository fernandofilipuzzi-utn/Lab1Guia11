using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej6_Infracciones_2_1_c
{
    class Acta
    {
        public double BaseUsada { get; private set; }
        public int Dni { get; private set; }
        public string Nombre { get; private set; }
        public double TipoVehiculo { get; private set; }
        public double SubTotal { get; private set; }
        public double AjusteTipoVehiculo { get; private set; }
        public double SubTotalAjustado { get; private set; }
        public bool PagoEnLugar { get; private set; }
        public double DescuentoPago { get; private set; }
        public double TotalAPagar { get; private set; }

        Infraccion[] infracciones;
        int cantInfracciones;

        public Acta(int dni, string nombre, int tipoVehiculo,  double baseUsada)
        {
            Dni = dni;
            Nombre = nombre;
            TipoVehiculo = tipoVehiculo;
            BaseUsada = baseUsada;

            infracciones = new Infraccion[100];
            cantInfracciones = 0;

        }

        public void Agregar(Infraccion infraccion)
        {
            infracciones[cantInfracciones++] = infraccion;

            SubTotal += infraccion.CalcularMontoInfraccion(BaseUsada);
        }

        public void Finalizar(bool pagaEnElLugar)
        {
            PagoEnLugar = pagaEnElLugar;

            AjusteTipoVehiculo = SubTotal * CalcularReajuste() / 100d;
            
            SubTotalAjustado = SubTotal + AjusteTipoVehiculo;

            if (PagoEnLugar==true) 
                DescuentoPago = SubTotalAjustado * 50 / 100d;

            TotalAPagar = SubTotalAjustado - DescuentoPago;
        }

        public double CalcularReajuste()
        {
            double porc = 0;
            switch (TipoVehiculo)
            {
                case 1: porc = 1; break;
                case 2: porc = 50; break;
                case 3: porc = 200; break;
            }
            return porc;
        }

        public string VerTicket()
        {
            string ticket = "";

            ticket += $"  {Dni,-10}{Nombre,40}\n";
            ticket += $"  {"Tipo vehículo: "}{TipoVehiculo} ejes - Base 1L/{BaseUsada:f2} $ar\n";

            ticket += "------------------------------\n";

            for (int n = 0; n < cantInfracciones; n++)
            {
                Infraccion selected = infracciones[n];
                ticket += $"  {selected.Descripcion.ToString() + "(" + selected.Uds.ToString() + ")",-50}{selected.CalcularMontoInfraccion(BaseUsada),10:f2}\n";
            }
            ticket += "------------------------------\n";

            ticket +=$"  {"     Subtotal",-50}{SubTotal,10:f2}\n";
            ticket +=$"  {"Por tipo de vehículo:(50%)",-50}{AjusteTipoVehiculo,10:f2}\n";
            ticket +=$"  {"     subtotal      $ar",-50}{SubTotalAjustado,10:f2}\n";
            ticket +=$"  {"Pago en efectivo (-50%)",-50}{DescuentoPago,10:f2}\n";
            ticket +=$"  {"     Total de la multa  $ar",-50}{TotalAPagar,10:f2}";

            return ticket;
        }
    }
}
