using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Update
{
    public class TramiteUpdate
    {
        private UpdateCityApp<Tramite> UpdateCityApp;

        public TramiteUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Tramite>(cityAppContext);
        }
        public Response<object> UpdateTramite(Tramite tramite)
        {
            return UpdateCityApp.Save(tramite);
        }
    }
}
