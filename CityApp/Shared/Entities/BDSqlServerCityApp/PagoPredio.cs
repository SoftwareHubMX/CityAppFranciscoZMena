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
    public class PagoPredio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPagoPredio { get; set; } = 0;
        public int PredioId { get; set; } = 0;
        public DateTime FehcaPago { get; set; } = Fecha.GetFechaMx();
        public double Valuado { get; set; } = 0;
        public double Rezago { get; set; } = 0;
        public double Recargo { get; set; } = 0;
        public double Normal { get; set; } = 0;
        public double Total { get; set; } = 0;
        public string Anotaciones { get; set; } = "NA";
        public string RFC { get; set; } = "NA";
        public int IdPredio { get; set; } = 0;

        [ForeignKey("IdPredio")]
        public virtual Predio? Predio { get; set; }

    }
}
