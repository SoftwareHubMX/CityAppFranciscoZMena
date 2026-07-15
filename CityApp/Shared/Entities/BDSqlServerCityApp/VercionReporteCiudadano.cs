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
    public class VercionReporteCiudadano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVercionReporteCiudadano { get; set; } = 0;
        public string Descripcion { get; set; } = "NA";
        public DateTime FechaReporte { get; set; } = Fecha.GetFechaMx();
        public int IdReporteCiudadano { get; set; } = 0;
        public int IdCuenta { get; set; } = 0;

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }

        [ForeignKey("IdReporteCiudadano")]
        public virtual ReporteCiudadano? ReporteCiudadano { get; set; }

        public virtual DireccionReporteCiudadano? DireccionReporteCiudadano { get; set; }
        public virtual List<EvidenciaReporteCiudadano>? EvidenciasReporteCiudadano { get; set; }
    }
}
