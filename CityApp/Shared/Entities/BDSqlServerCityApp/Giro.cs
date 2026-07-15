using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Giro
    {
        [Key]
        public int IdGiro { get; set; } = 0;
        public string TipoGiro { get; set; } = "NA";
    }
}
