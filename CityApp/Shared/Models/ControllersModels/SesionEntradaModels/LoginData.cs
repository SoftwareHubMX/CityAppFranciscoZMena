using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.SesionEntradaModels
{
    public class LoginData
    {
        public string Usuario { get; set; } = "NA";
        public string Password { get; set; } = "NA";
        public bool MantenerSesion { get; set; } = false;
        public int IdTipoTokenLogin { get; set; } = 0;
    }
}
