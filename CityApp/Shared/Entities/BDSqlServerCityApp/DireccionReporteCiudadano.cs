using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class DireccionReporteCiudadano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDireccionReporteCiudadano { get; set; } = 0;
        public string Localidad { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public double Latitud { get; set; } = 0;
        public double Longitud { get; set; } = 0;
        public int IdVercionReporteCiudadano { get; set; } = 0;

        [ForeignKey("IdVercionReporteCiudadano")]
        public virtual VercionReporteCiudadano? VercionReporteCiudadano { get; set; }
    }
}
