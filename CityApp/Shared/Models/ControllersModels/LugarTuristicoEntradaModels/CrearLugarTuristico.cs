using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels
{
    public class CrearLugarTuristico
    {
        public string Nombre { get; set; } = "NA";
        public string Descripcion { get; set; } = "NA";
        public string Telefono { get; set; } = "NA";
        public string UrlWebFacebook { get; set; } = "NA";
        public int IdTipoLugarTuristico { get; set; } = 0;
        public DateTime FechaFundacionConstruccionApertura { get; set; } = Fecha.GetFechaMx();
    }
}
