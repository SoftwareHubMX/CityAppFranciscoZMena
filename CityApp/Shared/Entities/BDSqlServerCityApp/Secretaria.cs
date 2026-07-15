using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Secretaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSecretaria { get; set; } = 0;
        public string NombreSecretaria { get; set; } = "NA";

        public virtual List<Dependencia>? Dependencias { get; set; } 
    }
}
