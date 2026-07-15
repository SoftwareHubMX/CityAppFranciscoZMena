using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ContactoMunicipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContactoMunicipio { get; set; } = 0;
        public string Direccion { get; set; } = "NA";
        public string Telefono { get; set; } = "NA";
        public string Web { get; set; } = "NA";
        public string Horario { get; set; } = "NA";

        public virtual List<RedSocialMunicipio>? RedesSocialesMunicipio { get; set; }
    }
}
