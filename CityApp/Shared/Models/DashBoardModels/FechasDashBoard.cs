using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.DashBoardModels
{
    public class FechasDashBoard
    {
        public int TipoFecha { get; set; } = 0;
        // hoy 0
        // año mes 1
        // de año a año 2
        // todo lo del año 3
        public int Year { get; set; } = 0;
        // todo lo del mes y año 4
        public int Mes { get; set; } = 0;
        public int Year2 { get; set; } = 0;
    }
}
