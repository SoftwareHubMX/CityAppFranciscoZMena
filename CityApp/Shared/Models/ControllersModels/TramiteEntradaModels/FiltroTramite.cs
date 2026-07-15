using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.TramiteEntradaModels
{
    public class FiltroTramite
    {
        public int IdTipoTramite { get; set; } = 0;
        public int IdSecretaria { get; set; } = 0;
        public int IdDependencia { get; set; } = 0;
        public string Concepto { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";

        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;

        public virtual List<int>? IdsDependencias { get; set; }
    }
}
