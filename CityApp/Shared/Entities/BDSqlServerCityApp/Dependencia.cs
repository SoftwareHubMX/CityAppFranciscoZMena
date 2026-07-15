using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Dependencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDependencia { get; set; } = 0;
        public string NombreDependencia { get; set; } = "NA";
        public int IdSecretaria { get; set; } = 0;
        [ForeignKey("IdSecretaria")]
        public virtual Secretaria? Secretaria { get; set; }

        public virtual List<Tramite>? Tramites { get; set; }
    }
}
