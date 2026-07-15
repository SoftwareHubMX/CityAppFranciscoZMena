using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.PredioEntradaModels
{
    public class CrearPredio
    {
        public string Clave { get; set; } = "NA";
        public string ClaveCatastral { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public int Numero { get; set; } = 0;
        public string Letra { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Poblacion { get; set; } = "NA";
        public string Ciudad { get; set; } = "NA";
        public string Estado { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public string Propietario { get; set; } = "NA";
        public bool MismaDireccion { get; set; } = false;
    }
}
