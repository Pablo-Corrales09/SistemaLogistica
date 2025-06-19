using LogiSmart.Interfaces;
using LogiSmart.Models.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models.VehicleFactory
{
    public class VehicleFactory 
    {
        public Vehiculo CrearVehiculo(int opcionVehiculo, string Placa, double Km)
        { 
            ITransportFactory vehiculo;           
            {
                switch (opcionVehiculo)
                {
                    case 1:
                        vehiculo = new MotoFactory();                        
                        
                        break;
                    case 2:
                        vehiculo = new CamionFactory();
                        
                        break;
                    case 3:
                        vehiculo = new FurgonetaFactory();
                        
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Por favor, elija un tipo de vehículo válido.");
                        return null;
                }
                return vehiculo.CrearVehiculo(Placa, Km);
                
            }
        }

    }// Fin clase VehicleFactory
}// Fin namespace LogiSmart.Models.VehicleFactory
