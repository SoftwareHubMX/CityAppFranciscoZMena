using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoReporteCiudadano
    {
        [Key]
        public int IdTipoReporteCiudadano { get; set; } = 0;
        public string TipoReporte { get; set; } = "NA";

        public virtual List<ReporteCiudadano>? ReportesCiudadanos { get; set; }
    }
}
