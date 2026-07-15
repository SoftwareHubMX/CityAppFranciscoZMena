using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Condicion
    {
        [Key]
        public int IdCondicion { get; set; } = 0;
        public string TipoCondicion { get; set; } = "NA";
    }
}
