using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class EvidenciaReporteCiudadano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnvidenciaReporteCiudadano { get; set; } = 0;
        public string Ruta { get; set; } = "NA";
        public string Formato { get; set; } = "NA";
        public int IdVercionReporteCiudadano { get; set; } = 0;

        [ForeignKey("IdVercionReporteCiudadano")]
        public virtual VercionReporteCiudadano? VercionReporteCiudadano { get; set; }
    }
}
