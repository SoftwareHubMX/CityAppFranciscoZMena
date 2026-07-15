using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels
{
    public class FiltroBolsaTrabajo
    {
        public int IdGiro { get; set; } = 0;
        public string Puesto { get; set; } = "NA";
        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
