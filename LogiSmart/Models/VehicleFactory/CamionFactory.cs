using LogiSmart.Interfaces;
using LogiSmart.Models.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogiSmart.Models.VehicleFactory
{
    public class CamionFactory : ITransportFactory
    {
        public Vehiculo CrearVehiculo(string Placa, double Km)
        {
            Placa = Placa.ToUpper(); // Se convierte la placa a mayúsculas para revisar el formato
            try
            {
                if (string.IsNullOrEmpty(Placa) || !Regex.IsMatch(Placa, @"^[A-Z0-9\-]+$"))
                //Verifica que la placa no sea nula y que tenga el formato correcto AAA-0000
                {
                    Console.WriteLine("\nPlaca inválida. Debe seguir el formato AAA-0000.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    throw new ArgumentException("Datos inválidos para agregar motocicleta.");
                }
                if (Km < 0)
                {
                    // Verifica que el kilometraje sea un número positivo
                    Console.WriteLine("\nKilometraje inválido. Debe ser un número positivo.");
                    Thread.Sleep(5000);
                    Console.Clear();
                    throw new ArgumentException("Kilometraje inválido. Debe ser un número positivo.");
                }
                return new VehiculoCamion(Placa, Km);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el camión: {ex.Message}");
                Thread.Sleep(5000);
                Console.Clear();
                return null; // Retorna null en caso de error
            }
        }

    }// Fin clase CamionFactory
}// Fin namespace LogiSmart.Models.VehicleFactory
