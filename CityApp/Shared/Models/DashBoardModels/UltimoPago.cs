using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.DashBoardModels
{
    public class UltimoPago
    {
        public string Nombre { get; set; } = "";
        public double Total { get; set; } = 0;
        public string Consepto { get; set; } = "";
        public DateTime Fecha { get; set; } = new DateTime();
    }
}
