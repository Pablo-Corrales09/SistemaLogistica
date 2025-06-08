using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models
{
    public class Ruta
    {
        public double DistanciaRuta { get; set; }

        public Ruta(double distanciaRuta)
        {
            DistanciaRuta = distanciaRuta;
        }
    }
}
