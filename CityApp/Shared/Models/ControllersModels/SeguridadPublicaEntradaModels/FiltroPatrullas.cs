using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels
{
    public class FiltroPatrullas
    {
        public string Placa { get; set; } = "NA";
        public string NumeroEconomico { get; set; } = "NA";
        public int Orden { get; set; } = 0;
        // 0 como se salga
        // 1 - 2 Id ASC - DESC
        // 3 - 4 Placa ASC - DESC
        // 5 - 6 Numero ASC - DESC
        //Sistema de paginacion
        public int MaximoPatrullas { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
