using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models
{
    public class VehiculoCamion : Vehiculo
    {

        private const double LARGO_CAJON_CAMION = 350; //cm
        private const double ANCHO_CAJON_CAMION = 200; //cm
        private const double ALTO_CAJON_CAMION = 160; //cm
        private const double PESO_MAXIMO_DE_CARGA = 2500; // Peso en gramos
        private const string LICENCIA_CAMION = "B2";
        private const int TIEMPO_MANTENIMIENTO_CAMIOM = 90; //90s


        public VehiculoCamion(string placa, double km) : base(placa, km)
        {
            Placa = placa;
            KilometrajeActual = km;
            TipoVehiculo = "Camion";
            TipoLicenciaAdmitida = LICENCIA_CAMION;
            EstadoVehiculo = EstadoVehiculo;
            DescripcionVehiculo = DescripVehiculo();
            AltoMaxPaquete = 30;
            AnchoMaxPaquete = 100;
            VolMaxDeCarga = VolDeCargaMaxima();
            PesoCargaMax = PESO_MAXIMO_DE_CARGA;
        }

        public override double VolDeCargaMaxima()
        {
            return LARGO_CAJON_CAMION * ANCHO_CAJON_CAMION * ALTO_CAJON_CAMION; // Calculo para el volumen de carga de un cajon rectangular
        }

        public override void realizarMantenimiento()
        {
            int tiempoTranscurrido = TIEMPO_MANTENIMIENTO_CAMIOM;
            Console.WriteLine($"\nInicio de mantenimiento, tiempo estimado: {TIEMPO_MANTENIMIENTO_CAMIOM} segundos.");
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

        public override bool ValidarLicencia(Conductor conductor)
        {
            if (LICENCIA_CAMION != conductor.LicenciaConductor)
            {
                Console.WriteLine($"\nLicencia inválida. Este vehículo requiere tipo de licencia: {TipoLicenciaAdmitida}");
                Thread.Sleep(5000);
                Console.Clear();
                return false;
            }
            return true;
        }

       
    }
}
