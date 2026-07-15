using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class SolicitudTipoJustificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSolicitudTipoJustificacion { get; set; } = 0;
        public int IdTipoJustificacionSolicitud { get; set; } = 0;
        public int IdSolicitudPoda { get; set; } = 0;

        [ForeignKey("IdTipoJustificacionSolicitud")]
        public virtual TipoJustificacionSolicitud? TiposJustificacionSolicitud { get; set; }

        [ForeignKey("IdSolicitudPoda")]
        public virtual SolicitudPoda? SolicitudesPoda { get; set; }


    }
}