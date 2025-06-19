using LogiSmart.Enums;
using LogiSmart.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models
{
    public class Conductor : IConducciones
    {
        // Atributos
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoLicencia LicenciaConductor { get; set; }
        public Experiencia NivelExperiencia { get; set; }
        public EstadoConduccion Estado { get; set; }
        public List<string> HistorialRutas { get; set; }

        // Constructor
        public Conductor(string cedula, string nombre, string apellido, TipoLicencia licencia, Experiencia experiencia)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            LicenciaConductor = licencia;
            NivelExperiencia = experiencia;
            Estado = EstadoConduccion.Disponible;
            HistorialRutas = new List<string>();
        }

        // Métodos de la interfaz
        public void IniciarConduccion()
        {
            if (Estado == EstadoConduccion.Disponible)
            {
                Estado = EstadoConduccion.EnEntrega;
                Console.WriteLine($"{Nombre} ha iniciado la conducción.");
            }
            else
            {
                Console.WriteLine("El conductor no se encuentra disponible para iniciar conducción.");
            }
        }

        public void TerminarConduccion()
        {
            Estado = EstadoConduccion.Disponible;
            Console.WriteLine($"{Nombre} ha Finalizado la conducción.");
        }

        public void AsignarVehiculo(string ruta)
        {
            if (Estado == EstadoConduccion.Disponible)
            {
                HistorialRutas.Add(ruta);
                Console.WriteLine($"{Nombre} ha sido asignado a la ruta: {ruta}");
            }
            else
            {
                Console.WriteLine("No se puede asignar vehículo: el conductor no está disponible.");
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"\nConductor: {Nombre} {Apellido}");
            Console.WriteLine($"Cédula: {Cedula}");
            Console.WriteLine($"Licencia: {LicenciaConductor}");
            Console.WriteLine($"Experiencia: {NivelExperiencia}");
            Console.WriteLine($"Estado: {Estado}");
            Console.WriteLine("Historial de rutas:");
            foreach (var ruta in HistorialRutas)
            {
                Console.WriteLine($" - {ruta}");
            }
        }
    
    } // Fin Clase conductor
} //Fin namespace LogiSmart.Models
