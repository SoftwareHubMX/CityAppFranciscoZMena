using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Solicitante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdSolicitante { get; set; } = 0;
        public string Nombre { get; set; } = "NA";
        public string RazonSocial { get; set; } = "NA";
        public string Direccion { get; set; } = "NA";
        public string Telefono { get; set; } = "NA";
        public string Correo { get; set; } = "NA";

        public int IdTipoSolicitud { get; set; } = 0;

        [ForeignKey("IdTipoSolicitud")]
        public virtual TipoSolicitud? TiposSolicitud { get; set; }
    }
}