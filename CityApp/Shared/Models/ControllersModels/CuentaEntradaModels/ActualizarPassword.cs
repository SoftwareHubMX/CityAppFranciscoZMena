using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.CuentaEntradaModels
{
    public class ActualizarPassword
    {
        public string Password { get; set; } = "NA";
        public bool CerrarSesiones { get; set; } = false;
    }
}
