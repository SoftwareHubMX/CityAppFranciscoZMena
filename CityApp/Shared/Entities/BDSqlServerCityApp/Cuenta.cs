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
    public class Cuenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuenta { get; set; } = 0;
        public string NombreUsuario { get; set; } = "NA";
        public string Password { get; set; } = "NA";
        public int IdRol { get; set; } = 0;

        public bool EstatusActivo { get; set; } = true;

        public DateTime FechaRegistro { get; set; } = Fecha.GetFechaMx();

        [ForeignKey("IdRol")]
        public virtual Rol? Rol { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual Contacto? Contacto { get; set; }
        public virtual List<DireccionUsuario>? DireccionesUsuario { get; set; }
        public virtual EstatusCuenta? EstatusCuenta { get; set; }
        public virtual ContadorAcceso? ContadorAcceso { get; set; }
        public virtual TokenActualizarPassword? TokenActualizarPassword { get; set; }
        public virtual TokenContadorAccesos? TokenContadorAccesos { get; set; }
        public virtual TokenVerificacionCorreo? TokenVerificacionCorreo { get; set; }
    }
}
