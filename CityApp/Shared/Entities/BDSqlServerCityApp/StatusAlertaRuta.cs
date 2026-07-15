using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class StatusAlertaRuta
    {
        [Key]
        public int IdStatusAlertaRuta { get; set; } = 0;
        public string StatusAlerta { get; set; } = "NA";
    }
}
