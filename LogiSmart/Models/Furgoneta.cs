using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models
{
    public class Furgoneta : Vehiculo
    {
        private const double LARGO_CAJON_FURGONETA = 180; //cm
        private const double ANCHO_CAJON_FURGONETA = 140; //cm
        private const double ALTO_CAJON_FURGONETA = 130; //cm
        private const double PESO_MAXIMO_DE_CARGA = 500; // Peso en gramos
        private const string LICENCIA_FURGONETA = "B1";
        private const int TIEMPO_MANTENIMIENTO_FURGONETA = 60; //Representado en segundos, 60s es 1 minuto 

        public Furgoneta(string placa, double km) : base(placa, km)
        {
            Placa = placa;
            KilometrajeActual = km;
            TipoVehiculo = "Furgoneta";
            TipoLicenciaAdmitida = LICENCIA_FURGONETA;
            EstadoVehiculo = EstadoVehiculo;
            DescripcionVehiculo = DescripVehiculo();
            AltoMaxPaquete = 30;
            AnchoMaxPaquete = 100;
            VolMaxDeCarga = VolDeCargaMaxima();
            PesoCargaMax = PESO_MAXIMO_DE_CARGA;
        }

        public override void realizarMantenimiento()
        {
              int tiempoTranscurrido = TIEMPO_MANTENIMIENTO_FURGONETA;
            Console.WriteLine($"\nInicio de mantenimiento, tiempo estimado: {TIEMPO_MANTENIMIENTO_FURGONETA} segundos.");
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
            if (LICENCIA_FURGONETA != conductor.LicenciaConductor)
            {
                Console.WriteLine($"\nLicencia inválida. Este vehículo requiere tipo de licencia: {TipoLicenciaAdmitida}");
                Thread.Sleep(5000);
                Console.Clear();
                return false;
            }
            return true;
        }

        public override double VolDeCargaMaxima()
        {
            return LARGO_CAJON_FURGONETA * ANCHO_CAJON_FURGONETA * ALTO_CAJON_FURGONETA; // Calculo para el volumen de carga de un cajon rectangular
        }
    }
}
