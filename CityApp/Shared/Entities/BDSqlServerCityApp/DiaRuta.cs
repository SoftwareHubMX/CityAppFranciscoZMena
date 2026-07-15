using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class DiaRuta
    {
        [Key]
        public int IdDiaRuta { get; set; } = 0;
        public string Dias { get; set; } = "NA";

        public int IdRutaRecoleccion { get; set; } = 0;

        [ForeignKey("IdRutaRecoleccion")]
        public virtual RutaRecoleccion? RutaRecoleccion { get; set; }
    }
}
