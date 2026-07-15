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
    public class LugarTuristico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLugarTuristico { get; set; } = 0;
        public string Nombre { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";
        public int IdTipoLugarTuristico { get; set; } = 0;
        public DateTime FechaFundacionConstruccionApertura { get; set; } = Fecha.GetFechaMx();
        public string Telefono { get; set; } = "NA";
        public string UrlWebFacebook { get; set; } = "NA";

        [ForeignKey("IdTipoLugarTuristico")]
        public virtual TipoLugarTuristico? TipoLugarTuristico { get; set; }

        public virtual DireccionLugarTuristico? DireccionLugarTuristico { get; set; }
        public virtual List<CaracteristicaLugarTuristico>? CaracteristicasLugarTuristico { get; set; }
        public virtual List<ArchivoLugarTuristico>? ArchivosLugarTuristico { get; set; }
    }
}
