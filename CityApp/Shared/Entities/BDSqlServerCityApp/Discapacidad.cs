using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Discapacidad
    {
        [Key]
        public int IdDicapacidad { get; set; } = 0;
        public string TipoDiscapacidad { get; set; } = "NA";
    }
}
