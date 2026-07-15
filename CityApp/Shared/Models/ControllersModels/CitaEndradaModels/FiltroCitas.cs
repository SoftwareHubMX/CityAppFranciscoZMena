using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.CitaEndradaModels
{
    public class FiltroCitas
    {
        public int IdCuenta { get; set; } = 0;
        public int IdTipoCita { get; set; } = 0;
        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
