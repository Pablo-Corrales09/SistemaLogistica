using LogiSmart.Enums;
using LogiSmart.Interfaces;
using LogiSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Menus
{
    public class Menu
    {
        private List<IConducciones> conductores = new List<IConducciones>();

        public void Ejecutar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Conductores ===");
                Console.WriteLine("1. Agregar conductor");
                Console.WriteLine("2. Listar conductores");
                Console.WriteLine("3. Asignar ruta a conductor");
                Console.WriteLine("4. Iniciar conducción");
                Console.WriteLine("5. Terminar conducción");
                Console.WriteLine("6. Salir");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarConductor();
                        break;
                    case "2":
                        ListarConductores();
                        break;
                    case "3":
                        AsignarRuta();
                        break;
                    case "4":
                        IniciarConduccion();
                        break;
                    case "5":
                        TerminarConduccion();
                        break;
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AgregarConductor()
        {
            Console.Clear();
            Console.WriteLine("--- Agregar nuevo conductor ---");
            Console.Write("Cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.WriteLine("Tipo de licencia: 1.Carro 2.Moto 3.Camión 4.Todas");
            Console.Write("Opción: ");
            string tipoLicStr = Console.ReadLine();
            TipoLicencia licencia = TipoLicencia.Carro;
            switch (tipoLicStr)
            {
                case "1": licencia = TipoLicencia.Carro; break;
                case "2": licencia = TipoLicencia.Moto; break;
                case "3": licencia = TipoLicencia.Camion; break;
                case "4": licencia = TipoLicencia.Todas; break;
            }

            Console.WriteLine("Experiencia: 1.Novato 2.Intermedio 3.Experto");
            Console.Write("Opción: ");
            string expStr = Console.ReadLine();
            Experiencia experiencia = Experiencia.Novato;
            switch (expStr)
            {
                case "1": experiencia = Experiencia.Novato; break;
                case "2": experiencia = Experiencia.Intermedio; break;
                case "3": experiencia = Experiencia.Experto; break;
            }

            Conductor nuevo = new Conductor(cedula, nombre, apellido, licencia, experiencia);
            conductores.Add(nuevo);

            Console.WriteLine("Conductor agregado. Presiona una tecla para volver al menú.");
            Console.ReadKey();
        }

        private void ListarConductores()
        {
            Console.Clear();
            Console.WriteLine("--- Lista de conductores ---");
            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores registrados.");
            }
            else
            {
                int i = 1;
                foreach (var c in conductores)
                {
                    Console.WriteLine($"Conductor #{i}:");
                    c.MostrarInformacion();
                    i++;
                }
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void AsignarRuta()
        {
            Console.Clear();
            Console.WriteLine("--- Asignar ruta ---");

            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores para asignar ruta.");
                Console.ReadKey();
                return;
            }

            int index = SeleccionarConductor();
            if (index == -1) return;

            Console.Write("Ingrese la ruta a asignar: ");
            string ruta = Console.ReadLine();

            conductores[index].AsignarVehiculo(ruta);

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void IniciarConduccion()
        {
            Console.Clear();
            Console.WriteLine("--- Iniciar conducción ---");

            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores registrados.");
                Console.ReadKey();
                return;
            }

            int index = SeleccionarConductor();
            if (index == -1) return;

            conductores[index].IniciarConduccion();

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private void TerminarConduccion()
        {
            Console.Clear();
            Console.WriteLine("--- Terminar conducción ---");

            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores registrados.");
                Console.ReadKey();
                return;
            }

            int index = SeleccionarConductor();
            if (index == -1) return;

            conductores[index].TerminarConduccion();

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        private int SeleccionarConductor()
        {
            Console.WriteLine("Selecciona el número del conductor:");

            for (int i = 0; i < conductores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {((Conductor)conductores[i]).Nombre} {((Conductor)conductores[i]).Apellido}");
            }
            Console.Write("Opción: ");
            bool valid = int.TryParse(Console.ReadLine(), out int opcion);

            if (!valid || opcion < 1 || opcion > conductores.Count)
            {
                Console.WriteLine("Opción inválida. Presiona una tecla para continuar...");
                Console.ReadKey();
                return -1;
            }
            return opcion - 1;
        }
    }
}
