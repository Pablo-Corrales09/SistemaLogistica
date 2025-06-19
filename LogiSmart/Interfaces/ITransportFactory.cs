using LogiSmart.Models;
using LogiSmart.Models.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Interfaces
{
    public interface ITransportFactory
    {
        Vehiculo CrearVehiculo(string Placa, double Km);

    }
}
