using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class TipoJustificacionSolicitud
    {
        [Key]
        public int IdTipoJustificacionSolicitud { get; set; } = 0;
        public string Tipo { get; set; } = "NA";
    }
}
