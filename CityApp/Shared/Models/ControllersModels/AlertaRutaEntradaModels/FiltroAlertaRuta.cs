using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels
{
    public class FiltroAlertaRuta
    {
        public int IdTipoAlertaRuta { get; set; }  = 0;
        public int IdStatusAlertaRuta { get; set; } = 0;
        public int IdRutaRecoleccion { get; set; } = 0;

        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;

        public virtual List<int>? IdsDiasRuta { get; set; }

    }
}
