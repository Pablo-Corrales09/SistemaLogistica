using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiSmart.Interfaces
{
    public interface IConducciones
    {
        void IniciarConduccion();
        void TerminarConduccion();
        void AsignarVehiculo(string ruta);
        void MostrarInformacion();
    }

}
