using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Models
{
    public class Paquete
    {
        public string Nombre { get; set; }
        public double Volumen { get; set; }
        public int Alto { get; set; }

        public double Peso { get; set; }

        public int Ancho { get; set; }

        public Paquete(string nombre, Double peso, int alto, int ancho)
        {
            Nombre = nombre;
            Volumen = peso;
            Alto = alto;
            Ancho = ancho;
        }
    } //Fin Clase
} //Fin namespace LogiSmart.Models
