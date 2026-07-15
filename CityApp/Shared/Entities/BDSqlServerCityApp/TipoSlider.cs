using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoSlider
    {
        [Key]
        public int IdTipoSlider { get; set; } = 0;
        public string Slider { get; set; } = "NA";
    }
}
