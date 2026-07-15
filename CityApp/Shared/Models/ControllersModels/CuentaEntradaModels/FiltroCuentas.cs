using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.CuentaEntradaModels
{
    public class FiltroCuentas
    {
        public int IdCuenta { get; set; } = 0;
        public int IdRol { get; set; } = 0;
        public string NombreUsuario { get; set; } = "NA";
        public bool EstatusActivo { get; set; } = true;
        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
 