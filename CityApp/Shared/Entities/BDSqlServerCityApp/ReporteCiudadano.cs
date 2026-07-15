using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ReporteCiudadano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReporteCiudadano { get; set; } = 0;
        public int IdTipoReporteCiudadano { get; set; } = 0;
        public int IdEstatusReporteCiudadano { get; set; } = 0;
        public DateTime FechaPrimerReporte { get; set; } = Fecha.GetFechaMx();
        public string Observaciones { get; set; } = "NA";

        [ForeignKey("IdTipoReporteCiudadano")]
        public virtual TipoReporteCiudadano? TipoReporteCiudadano { get; set; }

        [ForeignKey("IdEstatusReporteCiudadano")]
        public virtual EstatusReporteCiudadano? EstatusReporteCiudadano { get; set; }

        public virtual List<EvidenciaSolucionReporteCiudadano>? EvidenciasSolucionReporteCiudadano { get; set; }
        public virtual List<VercionReporteCiudadano>? VercionesReporteCiudadano { get; set; }
    }
}
