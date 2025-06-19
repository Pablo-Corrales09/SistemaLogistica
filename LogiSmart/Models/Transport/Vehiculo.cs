using LogiSmart.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models.Transport
{
    abstract public class Vehiculo
    {
        public string Placa { get; set; }
        public double VolMaxDeCarga { get; set; }
        public double KilometrajeActual { get; set; }
        public double KmMantenimiento { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
        public EstadoVehiculo EstadoVehiculo { get; set; }
        public string DescripcionVehiculo { get; set; }
        public TipoLicencia TipoLicenciaAdmitida { get; set; }
        public double VolDeCargaOcupado { get; set; }
        public int AltoMaxPaquete { get; set; }  // Para usarse como referencia para cm
        public int AnchoMaxPaquete { get; set; } // Para usarse como referencia para cm
        public string CentroDistribucion { get; set; }
        public double PesoPaqEnVehi { get; set; }
       public double PesoCargaMax { get; set; }

        private const double KM_PARA_MANTENIMIENTO = 10000;
        public Vehiculo()
        {
            Placa = "";
            KilometrajeActual = 0;
            KmMantenimiento = 0;
            TipoVehiculo = (TipoVehiculo)0;
            TipoLicenciaAdmitida = (TipoLicencia)0;
            EstadoVehiculo = (EstadoVehiculo)0;
            DescripcionVehiculo = "";
            CentroDistribucion = "";
            AltoMaxPaquete = 0; //cm
            AnchoMaxPaquete = 0; //cm
            VolMaxDeCarga = 0; //cm3
            PesoCargaMax = 0; //kgs
            VolDeCargaOcupado = 0; // cm3
            PesoPaqEnVehi = 0; // kgs

        }

        public abstract bool ValidarLicencia(Conductor conductor);

        public bool ValidarDisponibilidad()
        {
            if (EstadoVehiculo == EstadoVehiculo.Pendiente)
            {
                Console.WriteLine("\nPendiente: El vehículo no tiene centro de distribución asignado.");
                return false;
            }

            if (EstadoVehiculo != EstadoVehiculo.Disponible)
            {
                Console.WriteLine($"\nVehiculo no disponible: {EstadoVehiculo}");
                return false;
            }

            return true;
        }

        public abstract Vehiculo CrearVehiculo();

        public abstract double VolDeCargaMaxima();

        public bool ValidarTamanoPaquete(Paquete paquete)
        {
            try
            {
                if (paquete == null)
                {
                    throw new ArgumentNullException(nameof(paquete), "El parámetro no puede ser nulo");
                }
                if (paquete.Alto > AltoMaxPaquete || paquete.Ancho > AnchoMaxPaquete)
                {
                    Console.WriteLine("Error: El paquete excede las dimensiones permitidas para este vehículo");
                    return false;
                }
                if (paquete.Volumen + VolDeCargaOcupado > VolMaxDeCarga)
                /*Verifica que la suma del volumen del paquete y el volumen ya ocupado en el vehículo no supere el máximo permitido*/
                {
                    Console.WriteLine("Error: El peso del paquete supera el volumen máximo de carga del vehículo.");
                    return false;
                }
                if (paquete.Peso + PesoPaqEnVehi > PesoCargaMax)
                {
                    Console.WriteLine("Error: El volumen del paquete supera el peso de carga máximo soportado por el vehículo.");
                    return false;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR inesperado] {ex.Message}");
                return false;
            }
            return true;
        }

        public bool CargarPaquete(Paquete paquete)
        {
            /*Valida el tamaño del paquete y además verifica si el peso del paquete actual se puede cargar al vehículo
            o si por lo contraro excede la capacidad máxima de carga.*/
            if (ValidarTamanoPaquete(paquete) && VolDeCargaOcupado + paquete.Volumen <= VolMaxDeCarga)
            {
                VolDeCargaOcupado += paquete.Volumen;
                PesoPaqEnVehi += paquete.Peso;
                Console.WriteLine("Paquete cargado exitosamente.");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SumarKilometraje(Ruta ruta) {
            if (ruta == null) 
                throw new ArgumentNullException(nameof(ruta), "La ruta no puede ser nula.");

            if (ruta.DistanciaRuta <= 0) 
                throw new ArgumentOutOfRangeException(nameof(ruta.DistanciaRuta),"La distancia de la ruta debe ser mayor a cero.");
            
            KilometrajeActual += ruta.DistanciaRuta;
            KmMantenimiento += ruta.DistanciaRuta;
        }

        public bool ColocarEnRuta(Conductor conductor, Paquete paquete, Ruta ruta)
        {
            if (!ValidarDisponibilidad())
                return false;

            if (!ValidarDistanciaMantenimiento(ruta))
            {
                return false;
            }

            if (!ValidarLicencia(conductor))
            {
                return false;
            }

            CargarPaquete(paquete);//Los métodos de validación ya manejan los mensajes con los errores.                    
            EstadoVehiculo = EstadoVehiculo.EnRuta;
            SumarKilometraje(ruta);
            Console.WriteLine("\nRuta asignada exitosamente");
            return true;
        }

        public void RegistrarViaje(Ruta ruta, Conductor conductor)
        {
            if (ValidarLicencia(conductor)){
                if (KmMantenimiento >= 10000)
                {
                    PonerEnMantenimiento();
                    KilometrajeActual += ruta.DistanciaRuta;
                }
                else
                {
                    Console.WriteLine("\n¡Viaje completado con éxito!");
                    EstadoVehiculo = EstadoVehiculo.Disponible;
                }
            }else
            {
                Console.WriteLine("\nEl viaje no fue registrado.");
                Thread.Sleep(5000);
                Console.Clear();
                return;
            }
        }

        public  bool ValidarDistanciaMantenimiento(Ruta ruta)
        {
            if (KmMantenimiento + ruta.DistanciaRuta <= KM_PARA_MANTENIMIENTO)
            {
                return true;

            }
            EstadoVehiculo = EstadoVehiculo.RequiereMantenimiento;
            Console.WriteLine("\nLa ruta supera el kilometraje máximo antes del mantenimiento.");
            return false;
        }

        public bool PonerEnMantenimiento()
        {
            if (EstadoVehiculo != EstadoVehiculo.Mantenimiento)
            {
                EstadoVehiculo = EstadoVehiculo.Mantenimiento;
                realizarMantenimiento();
                return true;
            }
            return false;
        }

        public virtual string DescripVehiculo()
        {
            /*Al declarar el método como 'virtual' se puede tener el método con una forma en la clase base y la posibilidad de hacer overwrite 
             y modificar su comportamiento en las clases hijas.
             */
            return $"\nDetalles del vehículo\n\nTipo: {TipoVehiculo}.\nPlaca: {Placa}.\nEstado: {EstadoVehiculo}." +
                   $"\nLicencia requerida: {TipoLicenciaAdmitida}.\nCapacidad máxima: {VolMaxDeCarga} kgs.\nDimesiones máximas por paquete: {AltoMaxPaquete} cm alto y {AnchoMaxPaquete} cm ancho." +
                   $"\nKilometraje total recorrido: {KilometrajeActual} Km. \nKilometraje mantenimiento: {KmMantenimiento} Km.";
        }

        public abstract void realizarMantenimiento();



    } // Fin Clase Vehiculo
} // Fin namespace LogiSmart.Models
