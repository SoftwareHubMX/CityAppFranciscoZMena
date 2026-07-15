using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AlertaRutaLogic
{
    public class CrearAlertaRutaLogic
    {
        private AlertaRutaQuerys AlertaRutaQuerys;

        private AlertaRuta AlertaRuta;

        public CrearAlertaRutaLogic(CityAppContext cityAppContext, AlertaRuta alertaRuta)
        {
            AlertaRutaQuerys = new AlertaRutaQuerys(cityAppContext);

            AlertaRuta = alertaRuta;
        }

        public Response<object> Crear()
        {
            return AlertaRutaQuerys.InsertAlertaRuta(AlertaRuta);
        }
    }
}
