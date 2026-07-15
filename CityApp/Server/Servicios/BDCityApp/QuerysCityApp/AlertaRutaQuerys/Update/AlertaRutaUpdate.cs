using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Update
{
    public class AlertaRutaUpdate
    {
        private UpdateCityApp<AlertaRuta> UpdateCityApp;

        public AlertaRutaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<AlertaRuta>(cityAppContext);
        }

        public Response<object> UpdateAlertaRuta(AlertaRuta alertaRuta)
        {
            return UpdateCityApp.Save(alertaRuta);
        }
    }
}
