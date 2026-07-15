using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class Slider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSlider { get; set; } = 0;
        public string Titulo { get; set; } = "NA";
        public int IdTipoSlider { get; set; } = 0;

        [ForeignKey("IdTipoSlider")]
        public virtual TipoSlider? TipoSlider { get; set; }

        public virtual List<ArchivoSlider>? ArchivosSlider { get; set; }
    }
}
