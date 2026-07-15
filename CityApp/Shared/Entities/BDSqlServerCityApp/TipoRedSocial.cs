using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoRedSocial
    {
        [Key]
        public int IdTipoRedSocial { get; set; } = 0;
        public string RedSocial { get; set; } = "NA";
    }
}
