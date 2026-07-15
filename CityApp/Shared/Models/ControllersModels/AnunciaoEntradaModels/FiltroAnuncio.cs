using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels
{
    public class FiltroAnuncio
    {
        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
