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
    public class HistoricoPredio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistoricoPredio { get; set; } = 0;
        public string NotaActualizacion { get; set; } = "NA";
        public DateTime FechaHistorico { get; set; } = Fecha.GetFechaMx();
        public int IdCuenta { get; set; } = 0;

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }

        public virtual ArchivoHistoricoPredio? ArchivoHistoricoPredio { get; set; }
    }
}
