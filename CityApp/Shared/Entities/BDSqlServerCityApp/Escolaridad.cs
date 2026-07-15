using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Escolaridad
    {
        [Key]
        public int IdEscolaridad { get; set; } = 0;
        public string NombreEscolaridad { get; set; } = "NA";
    }
}
