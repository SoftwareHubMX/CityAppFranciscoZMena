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
    public class Alerta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlerta { get; set; } = 0;
        public DateTime FechaAlerta { get; set; } = Fecha.GetFechaMx(); 
        public int IdCuenta { get; set; } = 0;
        public int IdEstatusAlerta { get; set; } = 0;

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }

        [ForeignKey("IdEstatusAlerta")]
        public virtual EstatusAlerta? EstatusAlerta { get; set; }
        public virtual DireccionAlerta? DireccionAlerta { get; set; }
    }
}
