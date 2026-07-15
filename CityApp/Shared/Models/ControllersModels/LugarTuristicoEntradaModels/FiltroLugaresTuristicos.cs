using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels
{
    public class FiltroLugaresTuristicos
    {
        public string Busqueda { get; set; } = "NA";
        public string Nombre { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";
        public string Caracteristica { get; set; } = "NA";
        public string CaracteristicaData { get; set; } = "NA";
        public string Localidad { get; set; } = "NA";
        public string Colonia { get; set; } = "NA";
        public string Calle { get; set; } = "NA";
        public string Numero { get; set; } = "NA";
        public string CodigoPostal { get; set; } = "NA";
        public int IdTipoLugarTuristico { get; set; } = 0;
        public int Orden { get; set; } = 0;
        // 0 id desc
        // 1 - 2 Id ASC - DESC
        // 3 - 4 Nombre ASC - DESC
        // 5 - 6 Descripcion ASC - DESC
        // 7 - 8 IdTipoLugarTuristico ASC - DESC
        // 9 - 10 Direccion ASC - DESC
        // 11 - 12 Fecha ASC - DESC
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
        public int MaximoNoticias { get; set; } = 0;
        public int Pagina { get; set; } = 0;
    }
}
