using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.PagoEntradaModels
{
    public class CrearPago
    {
        public DateTime FechaPago { get; set; } = Fecha.GetFechaMx();
        public string Referencia { get; set; } = "NA";
        public string Identificador { get; set; } = "NA";
        public string Folio { get; set; } = "NA";
        public double Total { get; set; } = 0;
        public int IdTipoPago { get; set; } = 0;
    }
}
