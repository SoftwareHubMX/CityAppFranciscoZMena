using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.AgendaEntradaModels
{
    public class FiltroAgenda
    {
        public string Titulo { get; set; } = "NA";
        public string Busqueda { get; set; } = "NA";
        public TimeSpan Horario { get; set; } = TimeSpan.Zero;
        public string Lugar { get; set; } = "NA";
        public int Orden { get; set; } = 0;
        // 0 Fecha desc
        // 1 - 2 Id ASC - DESC
        // 3 - 4 Titulo ASC - DESC
        // 5 - 6 Texto ASC - DESC
        // 7 - 8 Fecha ASC - DESC
        // 9 - 10 Hora ASC - DESC
        // 11 - 12 Lugar ASC - DESC
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
        //Sistema de paginacion
        public int MaximoElementos { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
