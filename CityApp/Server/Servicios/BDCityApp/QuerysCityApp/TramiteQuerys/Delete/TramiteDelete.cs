using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Delete
{
    public class TramiteDelete
    {
        private DeleteCityApp<Tramite> DeleteCityApp;
        public TramiteDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Tramite>(cityAppContext);
        }
        public Response<object> DeleteTramite(Tramite tramite)
        {
            return DeleteCityApp.Save(tramite);
        }
    }
}
