using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Tramite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTramite { get; set; } = 0;
        public string Concepto { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";
        public string Direccion { get; set; } = "NA";
        public string Telefono { get; set; } = "NA";
        public string Requisitos { get; set; } = "NA";
        public double Costo { get; set; } = 0;
        public double Latitud { get; set; } = 0;
        public double Longitud { get; set; } = 0;
        public int IdDependencia { get; set; } = 0;
        public int IdTipoTramite { get; set; } = 0;
        public string Observaciones { get; set; } = "NA";

        [ForeignKey("IdDependencia")]
        public virtual Dependencia? Dependencia { get; set; }

        [ForeignKey("IdTipoTramite")]
        public virtual TipoTramite? TipoTramite { get; set; }

    }
}
