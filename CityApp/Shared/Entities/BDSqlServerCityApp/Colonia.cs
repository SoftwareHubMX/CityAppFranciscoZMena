using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Colonia
    {
        [Key]
        

        public int IdColonia { get; set; } = 0;
        public string NombreColonia { get; set; } = "NA";
        public double Latitud { get; set; } = 0;
        public double Lonitud { get; set; } = 0;
    }
}
