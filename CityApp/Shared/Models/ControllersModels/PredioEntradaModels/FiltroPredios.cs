using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.PredioEntradaModels
{
    public class FiltroPredios
    {
        public string Clave { get; set; } = "NA";
        public string ClaveCatastral { get; set; } = "NA";
        public string Usuario { get; set; } = "NA";
        public string Direccion { get; set; } = "NA";
        public string Poblacion { get; set; } = "NA";
        public string Ciudad { get; set; } = "NA";
        public string Estado { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public int Orden { get; set; } = 0;
        //Sistema de paginacion
        public int MaximoNoticias { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
