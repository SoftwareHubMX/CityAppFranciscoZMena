using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.SesionSalidaModels
{
    public class Sesion
    {
        public int IdCuenta { get; set; } = 0;
        public string NombreUsuario { get; set; } = "NA";
        public string Correo { get; set; } = "NA";
        public string TokenAcceso { get; set; } = "NA";
        public bool CorreoVerificado { get; set; } = false;
        public bool PerfilCompleto { get; set; } = false;
        public int IdRol { get; set; } = 0;
        public bool EstatusActivo { get; set; } = true;
    }
}
