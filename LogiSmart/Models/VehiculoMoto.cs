using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LogiSmart.Models
{
    public class VehiculoMoto : Vehiculo
    {
        private const double LADO_CAJON_MOTO = 30; //Lado en cm. La moto tiene un cajón cúbico.
        private const double PESO_MAXIMO_DE_CARGA = 40; // Peso en Kgs
        private const string LICENCIA_MOTO = "A2";
        private const int TIEMPO_MANTENIMIENTO_MOTO = 30; //30s


        public VehiculoMoto(string placa, double km) : base(placa, km)
        {
            Placa = placa;
            KilometrajeActual = km;
            TipoVehiculo = "Motocicleta";
            TipoLicenciaAdmitida = LICENCIA_MOTO;
            EstadoVehiculo = EstadoVehiculo;
            DescripcionVehiculo = DescripVehiculo();
            AltoMaxPaquete = 15;
            AnchoMaxPaquete = 30;
            VolMaxDeCarga = VolDeCargaMaxima();
            PesoCargaMax = PESO_MAXIMO_DE_CARGA;
        }

        public override double VolDeCargaMaxima()//Calcula el volumen de carga de una moto con un cajon cubico de 30cm por lado.
        {
            return Math.Pow(LADO_CAJON_MOTO, 3);  // Calculo para el volumen de carga de un cajon con forma de cubo

        }

        public override bool ValidarLicencia(Conductor conductor) 
        {
            if (LICENCIA_MOTO != conductor.LicenciaConductor)
            {
                Console.WriteLine($"\nLicencia inválida. Este vehículo requiere tipo de licencia: {TipoLicenciaAdmitida}");
                Thread.Sleep(5000);
                Console.Clear();
                return false;
            }
            return true;
        }

        public override void realizarMantenimiento()
        {
            int tiempoTranscurrido = TIEMPO_MANTENIMIENTO_MOTO;
            Console.WriteLine($"\nInicio de mantenimiento, tiempo estimado: {tiempoTranscurrido} segundos.");
            Thread.Sleep(5000);
            while (tiempoTranscurrido > 0)
            {
                TimeSpan tiempoReparacion = TimeSpan.FromSeconds(tiempoTranscurrido);
                Console.WriteLine("\nTiempo restante: " + tiempoReparacion.ToString(@"mm\:ss"));
                Thread.Sleep(1000);
                tiempoTranscurrido--;
                Console.Clear();
            }
            Console.WriteLine("\nMantenimiento finalizado.");
            KmMantenimiento = 0;
        }


    }//Fin clase
} //Fin namespace LogiSmart.Models
