using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public  class Cita
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdCita { get; set; } = 0;
        public string Nombre { get; set; } = "NA";
        public string ApellidoPaterno { get; set; } = "NA";
        public string ApellidoMaterno { get; set; } = "NA";
        public int Edad { get; set; } = 0;
        public string Telefono1 { get; set; } = "NA";
        public string Correo { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";
        public string Direccion { get; set; } = "NA";
        public int IdTipoCita { get; set; } = 0;
        public int IdCuenta { get; set; } = 0;
       
        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }

        [ForeignKey("IdTipoCita")]
        public virtual TipoCita? TipoCita { get; set; }
    }
}
