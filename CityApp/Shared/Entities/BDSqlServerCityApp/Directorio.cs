using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Directorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdDirectorio { get; set; } = 0;
        public string NombreDirecctorio { get; set; } = "NA";
        public string Puesto { get; set; } = "NA";
        public string MetodoContacto { get; set; } = "NA";
        public int IdTipoDirectorio { get; set; } = 0;
        public virtual List<ArchivoDirectorio>? ArchivosDirectorio { get; set; }

        [ForeignKey("IdTipoDirectorio")]
        public virtual TipoDirectorio? TipoDirectorio { get; set; }
    }
}
