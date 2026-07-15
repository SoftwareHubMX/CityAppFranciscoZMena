using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Insert
{
    public class AlertaRutaInsert
    {
        private InsertCityApp<AlertaRuta> InsertCityApp;

        public AlertaRutaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<AlertaRuta>(cityAppContext);
        }

        public Response<object> InsertAlertaRuta(AlertaRuta alertaRuta)
        {
            return InsertCityApp.Save(alertaRuta);
        }
    }
}
