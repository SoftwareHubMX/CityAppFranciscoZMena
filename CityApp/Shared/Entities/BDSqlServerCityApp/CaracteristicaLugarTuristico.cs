using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class CaracteristicaLugarTuristico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCaracteristicaLugarTuristico { get; set; } = 0;
        public string NombreCaracteristica { get; set; } = "NA";
        public string Caracteristica { get; set; } = "NA";
        public int IdLugarTuristico { get; set; } = 0;

        [ForeignKey("IdLugarTuristico")]
        public virtual LugarTuristico? LugarTuristico { get; set; }
    }
} 
