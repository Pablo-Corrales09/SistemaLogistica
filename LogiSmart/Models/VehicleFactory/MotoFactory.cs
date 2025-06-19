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
    public class MotoFactory : ITransportFactory
    {
        public Vehiculo CrearVehiculo(string Placa, double Km)
        {
                return new VehiculoMoto(Placa, Km);
            }
        }
    }// Fin clase MotoFactory
}// Fin namespace LogiSmart.Models.VehicleFactory
