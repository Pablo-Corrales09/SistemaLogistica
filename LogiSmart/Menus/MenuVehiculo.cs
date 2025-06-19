using LogiSmart.Models.Transport;
using LogiSmart.Models.VehicleFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogiSmart.Menus
{
    public class MenuVehiculo
    {
        VehicleFactory factory = new VehicleFactory();
        public List<Vehiculo> vehiculos = new List<Vehiculo>();

        public void MostrarMenuVehiculo()
        {
            bool menu = true;

            while (menu)
            {
                Console.Clear();
                Console.WriteLine("<---------- Menú vehículos ---------->");
                Console.WriteLine("\n1. Agregar Vehiculo.");
                Console.WriteLine("2. Mostrar Todos los vehiculos.");
                Console.WriteLine("3. Colocar en ruta.");
                Console.WriteLine("4. Enviar a mantenimiento.");
                Console.WriteLine("5. Salir.");
                Console.Write("\nElige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarVehiculo();
                        break;
                    case "2":
                        MostrarVehiculos();
                        break;
                    case "3":
                        //AsignarRuta();
                        break;
                    case "4":
                        //EnviarMantenimiento(); ;
                        break;
                    case "5":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void AgregarVehiculo()
        {
            bool CrearVehiculo = true;
            Console.WriteLine("\nIngrese la opción que corresponde al tipo de vehículo que desea agregar:" +
                "\n\n1 - Motocicleta.\n2 - Camión.\n3 - Furgoneta.\n");
            int opcionVehiculo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nIngrese la placa del vehículo:");
            string Placa = Console.ReadLine().ToUpper();
            if (!ValidarPlaca(Placa)) {
                return; // Sale del método si la placa es inválida
            }
            Console.WriteLine("\nIngrese el kilometraje del vehículo:");
            double Km = Convert.ToDouble(Console.ReadLine());
            if (!ValidarKilometraje(Km)) {
                return;
            }
            else
            {
                Vehiculo miVehiculo = factory.CrearVehiculo(opcionVehiculo, Placa, Km);
                vehiculos.Add(miVehiculo);
                Thread.Sleep(5000); // Espera 5 segundos para que el usuario vea el mensaje
                Console.Clear();
            }
        }

        public bool ValidarPlaca(string Placa)
        {
            if (string.IsNullOrEmpty(Placa) || !Regex.IsMatch(Placa, @"^[A-Z0-9\-]+$"))
            {
                Console.WriteLine("\nPlaca inválida. Debe seguir el formato AAA-0000.");
                Thread.Sleep(4000);
                Console.Clear();
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidarKilometraje(double Km)
        {
            if (Km < 0 || double.IsNaN(Km) )
            {
                Console.WriteLine("\nKilometraje inválido. El dato no puede contener caracteres especiales o ser un número negativo.");
                Thread.Sleep(4000);
                Console.Clear();
                return false;
            }
            return true;
        }

        public void MostrarVehiculos()
        {
            Console.Clear();
            if (vehiculos.Count == 0)
            {
                Console.WriteLine("\nNo hay vehículos registrados.");
                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nVehículos registrados:");
                vehiculos.ForEach(v => Console.WriteLine(v.DescripVehiculo()));
                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
        }

        public void AsignarRuta()
        {
            // Aquí se implementaría la lógica para asignar una ruta a un vehículo.
            // Por ejemplo, podrías solicitar al usuario que ingrese el ID del vehículo y la ruta.
            Console.WriteLine("\nFuncionalidad de asignación de ruta aún no implementada.");
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }



    }//Fin de la clase MenuVehiculo
}// Fin del namespace LogiSmart.Menus
