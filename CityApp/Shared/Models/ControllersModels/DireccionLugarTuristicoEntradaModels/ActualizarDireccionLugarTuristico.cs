using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels
{
    public class ActualizarDireccionLugarTuristico
    {
        public string Localidad { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public double Latitud { get; set; } = 0;
        public double Longitud { get; set; } = 0;
        public int IdLugarTuristico { get; set; } = 0;
    }
}
