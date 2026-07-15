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
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPago { get; set; } = 0;
        public DateTime FechaPago { get; set; } = Fecha.GetFechaMx();
        public string Referencia { get; set; } = "NA";
        public string Identificador { get; set; } = "NA";
        public string Folio { get; set; } = "NA";
        public double Total { get; set; } = 0;
        public int IdTipoPago { get; set; } = 0;
        public int IdCuenta { get; set; } = 0;
        public int IdEstatusPago { get; set; } = 0;

        [ForeignKey("IdTipoPago")]
        public virtual TipoPago? TipoPago { get; set; }

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }

        [ForeignKey("IdEstatusPago")]
        public virtual EstatusPago? EstatusPago { get; set; }
    }
}