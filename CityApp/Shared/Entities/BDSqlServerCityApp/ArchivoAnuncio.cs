using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ArchivoAnuncio
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdArchivoAnuncio { get; set; } = 0;
        public string Ruta { get; set; } = "NA";
        public string Formato { get; set; } = "NA";
        public bool Principal { get; set; } = false;
        public int IdAnuncio { get; set; } = 0;

        [ForeignKey("IdAnuncio")]
        public virtual Anuncio? Anuncios { get; set; }
    }
}
