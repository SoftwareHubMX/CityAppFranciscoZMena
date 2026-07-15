using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoPago
    {
        [Key]
        public int IdTipoPago { get; set; } = 0;
        public string Pago { get; set; } = "NA";
        public double Precio { get; set; } = 0;
    }
}
