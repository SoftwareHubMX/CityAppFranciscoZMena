using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class RutaRecoleccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRutaRecoleccion { get; set; } = 0;
        public string Concecionario { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";
        public string NombreRuta { get; set; } = "NA";
        public string Horario { get; set; } = "NA";
        public int IdCuenta { get; set; } = 0;

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }
        public virtual List<ColoniaRutaRecoleccion>? ColoniaRutaRecolecciones { get; set; }
        public virtual List<DiaRuta>? DiasRuta { get; set; }
        public virtual List<AlertaRuta>? AlertasRutas { get; set; }
        
    }
}
