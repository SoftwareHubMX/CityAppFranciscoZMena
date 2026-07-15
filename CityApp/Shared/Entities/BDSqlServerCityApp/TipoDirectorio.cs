using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoDirectorio
    {
        [Key]
        public int IdTipoDirectorio { get; set; } = 0;
        public string Directorio { get; set; } = "NA";
    }
}
