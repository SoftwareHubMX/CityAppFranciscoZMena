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
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgenda { get; set; } = 0;
        public string Titulo { get; set; } = "NA";
        public string Texto { get; set; } = "NA";
        public DateTime FechaPublicacion { get; set; } = Fecha.GetFechaMx();
        public string Hora { get; set; } = "NA";
        public string Lugar { get; set; } = "NA";
        public string EnlaceWeb { get; set; } = "NA";

        public virtual List<ArchivoAgenda>? ArchivosAgenda { get; set; }
    }
}
