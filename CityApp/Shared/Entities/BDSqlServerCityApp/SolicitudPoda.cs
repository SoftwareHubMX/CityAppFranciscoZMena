using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class SolicitudPoda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdSolicitudPoda { get; set; } = 0;
        public string Nombre { get; set; } = "NA";
        public int NumeroArboles { get; set; } = 0;
        public string Direccion { get; set; } = "NA";
        public string Referencias { get; set; } = "NA";
        public double Latidud { get; set; } = 0;
        public double Longitud { get; set; } = 0;
        public int IdSolicitante { get; set; } = 0;

        [ForeignKey("IdSolicitante")]
        public virtual Solicitante? Solicitantes { get; set; }

        public virtual List<SolicitudTipoJustificacion>? SolicitudesTipoJustificaciones { get; set; }
        public virtual List<ArchivoSolicitidPoda>? ArchivosSolicitudPoda { get; set; }

    }
}