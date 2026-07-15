using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoAlertaRuta
    {
        [Key]
        public int IdTipoAlertaRuta { get; set; } = 0;
        public string TipoAlerta { get; set; } = "NA"; 
    }
}
