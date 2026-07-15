using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ArchivoHistoricoPredio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArchivoHistoricoPredio { get; set; } = 0;
        public string Ruta { get; set; } = "NA";
        public string Formato { get; set; } = "NA";
        public bool Principal { get; set; } = false;
        public int IdHistoricoPredio { get; set; } = 0;

        [ForeignKey("IdHistoricoPredio")]
        public virtual HistoricoPredio? HistoricoPredio { get; set; }
    }
}
