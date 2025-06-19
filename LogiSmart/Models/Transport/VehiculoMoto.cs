using LogiSmart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace LogiSmart.Models.Transport
{
    public class VehiculoMoto : Vehiculo
    {
        private const double LADO_CAJON_MOTO = 30; //Lado en cm. La moto tiene un cajón cúbico.
        private const double PESO_MAXIMO_DE_CARGA = 40; // Peso en Kgs
        private const TipoLicencia LICENCIA_MOTO = TipoLicencia.Moto;
        private const int TIEMPO_MANTENIMIENTO_MOTO = 30; //30s


        public VehiculoMoto(string placa, double km) : base()
        {
            Placa = placa;
            KilometrajeActual = km;
            TipoVehiculo = TipoVehiculo.Moto;
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

        public override Vehiculo CrearVehiculo()
        {
            Console.WriteLine("\nIngrese el número de placa de la motocicleta: ");
            string placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa) || Regex.IsMatch(placa,@"^[A-Z]{3}-\d{4}$")) {
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
            return new VehiculoMoto(placa, km);
        }
    }//Fin clase
} //Fin namespace LogiSmart.Models
