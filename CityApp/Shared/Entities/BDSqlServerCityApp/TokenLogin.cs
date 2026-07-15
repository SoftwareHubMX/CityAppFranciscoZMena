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
    public class TokenLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTokenLogin { get; set; } = 0;
        public string Token { get; set; } = "";
        public DateTime FechaAcceso { get; set; } = Fecha.GetFechaMx();
        public bool MantenerSesion { get; set; } = false;
        public int IdTipoTokenLogin { get; set; } = 0;
        public int IdCuenta { get; set; } = 0;

        [ForeignKey("IdTipoTokenLogin")]
        public virtual TipoTokenLogin? TipoTokenLogin { get; set; }
    }
}
