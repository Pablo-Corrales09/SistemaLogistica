using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models
{
    public class Conductor
    {
        public string Nombre { get; set; }
        public string LicenciaConductor { get; set; }

        public Conductor(string nombre, string licencia)
        {
            Nombre = nombre;
            LicenciaConductor = licencia;
        }
    } // Fin Clase conductor
} //Fin namespace LogiSmart.Models
