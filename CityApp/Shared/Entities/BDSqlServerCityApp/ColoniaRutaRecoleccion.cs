using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ColoniaRutaRecoleccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdColoniaRutaRecoleccion { get; set; } = 0;
        public int IdColonia { get; set; } = 0; 
        public int IdRutaRecoleccion { get; set; } = 0;

        [ForeignKey("IdColonia")]
        public virtual Colonia? Colonia { get; set; }

        [ForeignKey("IdRutaRecoleccion")]
        public virtual RutaRecoleccion? RutaRecoleccion { get; set; }


    }
}
