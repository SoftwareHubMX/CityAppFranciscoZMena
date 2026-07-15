using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AlertaRutaLogic
{
    public class ActualizarAlertaRutaLogic
    {
        private AlertaRutaQuerys AlertaRutaQuerys;
        private AlertaRuta AlertaRuta;
        public ActualizarAlertaRutaLogic(CityAppContext cityAppContext, AlertaRuta alertaRuta)
        {
            AlertaRutaQuerys = new AlertaRutaQuerys(cityAppContext);

            AlertaRuta = alertaRuta;
        }

        public Response<object> Actualizar()
        {
            return AlertaRutaQuerys.UpdateAlertaRuta(AlertaRuta);
        }
    }
}
