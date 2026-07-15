using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class DireccionUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDireccionUsuario { get; set; } = 0;
        public string Localidad { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public string Latitud { get; set; } = "NA";
        public string Longitud { get; set; } = "NA";
        public int IdCuenta { get; set; } = 0;

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }
    }
}
