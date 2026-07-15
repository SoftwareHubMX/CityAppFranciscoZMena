using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels
{
    public class CrearReporteCiudadano
    {
        public int IdTipoReporteCiudadano { get; set; } = 0;
        public string Descripcion { get; set; } = "NA";
        public double Latitud { get; set; } = 0;
        public double Longitud { get; set; } = 0;
        public string Localidad { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
    }
}
