using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels
{
    public class FiltroDescuentoPredios
    {
        public string Titulo { get; set; } = "NA";
        public bool PorsentajeMonto { get; set; } = false;
        public double Descuento { get; set; } = 0;
        public int Orden { get; set; } = 0;
        // 0 Fecha desc
        // 1 - 2 Id ASC - DESC
        // 3 - 4 Referencia ASC - DESC
        // 5 - 6 TipoPago ASC - DESC
        // 7 - 8 IdCuenta ASC - DESC
        // 9 - 10 Fecha ASC - DESC
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
