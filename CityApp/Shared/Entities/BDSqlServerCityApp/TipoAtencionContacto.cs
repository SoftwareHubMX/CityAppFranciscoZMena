using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoAtencionContacto
    {
        [Key]
        public int IdTipoAtencionContacto { get; set; } = 0;
        public string TipoAtencion { get; set; } = "NA";
    }
}
