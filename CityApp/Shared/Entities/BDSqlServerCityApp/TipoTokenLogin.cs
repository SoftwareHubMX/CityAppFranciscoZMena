using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoTokenLogin
    {
        [Key]
        public int IdTipoTokenLogin { get; set; } = 0;
        public string TipoToken { get; set; } = "NA";
    }
}
