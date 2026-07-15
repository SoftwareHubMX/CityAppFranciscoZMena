using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.PredioSalidaModels
{
    public class InformacionPagoPredio
    {
        public int IdPredio { get; set; } = 0;
        public string Clave { get; set; } = "NA";
        public string ClaveCatastral { get; set; } = "NA";
        public bool Atrasado { get; set; } = false;
        public double ValorCatastral { get; set; } = 10;
        public double ValorFiscal { get; set; } = 10;
        public double Total { get; set; } = 10;
        public DateTime FechaUltimoPago { get; set; } = Fecha.GetFechaMx();
        public PropietarioPagoPredio PropietarioPagoPredio { get; set; } = new PropietarioPagoPredio();
        public DireccionPagoPredio DireccionPagoPredio { get; set; } = new DireccionPagoPredio();
    }
}
