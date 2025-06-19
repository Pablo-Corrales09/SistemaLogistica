using LogiSmart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogiSmart.Models.Transport
{
    public class VehiculoFurgoneta : Vehiculo
    {
        private const double LARGO_CAJON_FURGONETA = 180; //cm
        private const double ANCHO_CAJON_FURGONETA = 140; //cm
        private const double ALTO_CAJON_FURGONETA = 130; //cm
        private const double PESO_MAXIMO_DE_CARGA = 500; // Peso en gramos
        private const TipoLicencia LICENCIA_FURGONETA = TipoLicencia.Furgoneta;
        private const int TIEMPO_MANTENIMIENTO_FURGONETA = 60; //Representado en segundos, 60s es 1 minuto 

        public VehiculoFurgoneta(string placa, double km) : base()
        {
            Placa = placa;
            KilometrajeActual = km;
            TipoVehiculo = TipoVehiculo;
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

        public override Vehiculo CrearVehiculo()
        {
            Console.WriteLine("\nIngrese el número de placa de la furgoneta: ");
            string placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa) || Regex.IsMatch(placa, @"^[A-Z]{3}-\d{4}$"))
            {
                Console.WriteLine("\nPlaca inválida. Debe seguir el formato AAA-0000.");
                Thread.Sleep(5000);
                Console.Clear();
                return CrearVehiculo(); // Llamada recursiva para volver a solicitar la placa
            }
            Console.WriteLine("\nIngrese el kilometraje actual de la motocicleta: ");
            double km = Convert.ToDouble(Console.ReadLine());
            if (km < 0)
            {
                Console.WriteLine("\nKilometraje inválido. Debe ser un número positivo.");
                Thread.Sleep(5000);
                Console.Clear();
                return CrearVehiculo(); // Llamada recursiva para volver a solicitar el kilometraje
            }
            return new VehiculoFurgoneta(placa, km);
        }


    }// Fin Clase VehiculoFurgoneta
}//Fin namespace LogiSmart.Models.Transport
