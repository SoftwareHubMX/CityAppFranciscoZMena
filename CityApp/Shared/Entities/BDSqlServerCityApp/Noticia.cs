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
    public class Noticia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNoticia { get; set; } = 0;
        public string Titulo { get; set; } = "NA";
        public string Texto { get; set; } = "NA";
        public string Fuente { get; set; } = "NA";
        public string Autor { get; set; } = "NA";
        public DateTime FechaPublicacion { get; set; } = Fecha.GetFechaMx();
        public string EnlaceFacebook { get; set; } = "NA";
        public string EncaleWeb { get; set; } = "NA";

        public virtual List<ArchivoNoticia>? ArchivosNoticia { get; set; }
    }
}
