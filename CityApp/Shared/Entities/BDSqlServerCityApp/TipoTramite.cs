using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoTramite
    {
        [Key]
        public int IdTipoTramite { get; set; } = 0;
        public string NombreTramite { get; set; } = "NA";
    }
}
