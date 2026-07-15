using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Update
{
    public class AlertaUpdate
    {
        private UpdateCityApp<Alerta> UpdateCityApp;

        public AlertaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Alerta>(cityAppContext);
        }

        public Response<object> UpdateAlerta(Alerta alerta)
        {
            return UpdateCityApp.Save(alerta);
        }
    }
}
