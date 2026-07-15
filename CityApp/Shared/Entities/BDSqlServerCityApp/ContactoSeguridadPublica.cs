using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class ContactoSeguridadPublica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContactoSeguridadPublica { get; set; } = 0;
        public string Descripcion { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public int IdTipoAtencionContacto { get; set; } = 0;

        [ForeignKey("IdTipoAtencionContacto")]
        public virtual TipoAtencionContacto? TipoAtencionContacto { get; set; }
    }
}
