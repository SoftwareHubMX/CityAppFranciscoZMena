using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoCita
    {
        [Key]
        public int IdTipoCita { get; set; } = 0;
        public string Tipo { get; set; } = "NA";
    }
}
