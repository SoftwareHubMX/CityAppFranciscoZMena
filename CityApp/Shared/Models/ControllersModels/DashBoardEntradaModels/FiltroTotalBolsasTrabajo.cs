using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels
{
    public class FiltroTotalBolsasTrabajo
    {
        public int FiltroFechas { get; set; } = 0;
        // No filtrar fechas 0
        // solo esta fecha 1
        public DateTime FechaFija { get; set; } = Fecha.GetFechaMx();
        // entre este rango de fechas 2
        public DateTime FechaInicio { get; set; } = Fecha.GetFechaMx();
        public DateTime FechaFin { get; set; } = Fecha.GetFechaMx();
        // todo lo del año 3
        public int Year { get; set; } = 0;
        // todo lo del mes y año 4
        public int Mes { get; set; } = 0;
    }
}
