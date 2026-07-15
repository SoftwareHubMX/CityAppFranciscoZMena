using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; } = 0;
        public string NombreRol { get; set; } = "NA";

        public virtual List<Cuenta>? Cuentas { get; set; }
    }
}
