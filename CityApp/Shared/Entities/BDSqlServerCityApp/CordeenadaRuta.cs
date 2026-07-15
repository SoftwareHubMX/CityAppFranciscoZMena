using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class CordeenadaRuta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdCordeenadaRuta { get; set; } = 0;
        public double latitud { get; set; } = 0;
        public double Longitud { get; set; } = 0;
        public int IdRutaRecoleccion { get; set; } = 0;

        [ForeignKey("IdRutaRecoleccion")]
        public virtual RutaRecoleccion? RutaRecoleccion { get; set; }
    }
}
