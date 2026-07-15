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
    public class AlertaRuta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlertaRuta { get; set; } = 0;
        public string Descripcion { get; set; } = "NA";
        public DateTime FechaAlerta { get; set; } = Fecha.GetFechaMx();
        public int IdTipoAlertaRuta { get; set; } = 0;
        public int IdStatusAlertaRuta { get; set; } = 0;
        public int IdRutaRecoleccion { get; set; } = 0;

        [ForeignKey("IdTipoAlertaRuta")]
        public virtual TipoAlertaRuta? TiposAlertaRuta { get; set; }

        [ForeignKey("IdStatusAlertaRuta")]
        public virtual StatusAlertaRuta? StatusAlertaRuta { get; set; }

        [ForeignKey("IdRutaRecoleccion")]
        public virtual RutaRecoleccion? RutaRecoleccion { get; set; }
    }
}
