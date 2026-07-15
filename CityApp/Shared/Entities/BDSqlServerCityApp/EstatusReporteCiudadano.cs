using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class EstatusReporteCiudadano
    {
        [Key]
        public int IdEstatusReporteCiudadano { get; set; } = 0;
        public string Estatus { get; set; } = "NA";

        public virtual List<ReporteCiudadano>? ReportesCiudadanos { get; set; }
    }
}
