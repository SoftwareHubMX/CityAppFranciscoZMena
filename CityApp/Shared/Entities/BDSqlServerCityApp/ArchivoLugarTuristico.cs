using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ArchivoLugarTuristico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdArchivoLugarTuristico { get; set; } = 0;
        public string Ruta { get; set; } = "NA";
        public string Formato { get; set; } = "NA";
        public DateTime FechaArchivo { get; set; } = Fecha.GetFechaMx();
        public int IdLugarTuristico { get; set; } = 0;

        [ForeignKey("IdLugarTuristico")]
        public virtual LugarTuristico? LugarTuristico { get; set; }
    }
} 