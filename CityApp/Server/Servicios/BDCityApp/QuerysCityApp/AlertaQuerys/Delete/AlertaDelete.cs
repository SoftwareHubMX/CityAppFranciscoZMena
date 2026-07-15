using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Delete
{
    public class AlertaDelete
    {
        private DeleteCityApp<Alerta> DeleteCityApp;

        public AlertaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Alerta>(cityAppContext);
        }

        public Response<object> DeleteAlerta(Alerta alerta)
        {
            return DeleteCityApp.Save(alerta);
        }
    }
}
