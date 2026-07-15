using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class EvidenciaSolucionReporteCiudadano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnvidenciaSolucionReporteCiudadano { get; set; } = 0;
        public string Ruta { get; set; } = "NA";
        public string Formato { get; set; } = "NA";
        public string Observaciones { get; set; } = "NA";//
        public int IdReporteCiudadano { get; set; } = 0;
        public int IdCuenta { get; set; } = 0;

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }

        [ForeignKey("IdReporteCiudadano")]
        public virtual ReporteCiudadano? ReporteCiudadano { get; set; }
    }
}
