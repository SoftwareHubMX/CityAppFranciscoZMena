using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class StatusBolsa
    {
        [Key]
        public int IdStatusBolsa { get; set; } = 0;
        public string StatusBolsaTrabajo { get; set; } = "NA";
    }
}
