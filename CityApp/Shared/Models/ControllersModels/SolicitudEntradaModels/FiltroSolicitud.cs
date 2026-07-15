using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.SolicitanteEntradaModels
{
    public class FiltroSolicitud
    {
        public int IdTipoJustificacioSolicitud { get; set; } = 0;
        public int MaximoNoticias { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
