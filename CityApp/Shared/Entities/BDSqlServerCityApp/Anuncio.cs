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
    public class Anuncio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdAnuncio { get; set; } = 0;
        public string Titulo { get; set; } = "NA";
        public DateTime FechaPublicacion { get; set; } = Fecha.GetFechaMx();
        public virtual List<ArchivoAnuncio>? ArchivosAnuncio { get; set; }

    }
}
