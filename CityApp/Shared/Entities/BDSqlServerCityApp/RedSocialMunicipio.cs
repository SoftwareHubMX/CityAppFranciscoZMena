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
    public class RedSocialMunicipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRedSocialMunicipio { get; set; } = 0;
        public string Ruta { get; set; } = "NA";
        public int IdTipoRedSocial { get; set; } = 0;
        public int IdContactoMunicipio { get; set; } = 0;

        [ForeignKey("IdContactoMunicipio")]
        public virtual ContactoMunicipio? ContactoMunicipio { get; set; }

        [ForeignKey("IdTipoRedSocial")]
        public virtual TipoRedSocial? TipoRedSocial { get; set; }
    }
}
