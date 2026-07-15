using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Delete
{
    public class SolicitudPodaDelete
    {
        private DeleteCityApp<SolicitudPoda> DeleteCityApp;

        public SolicitudPodaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<SolicitudPoda>(cityAppContext);
        }

        public Response<object> DeleteSolicitudPoda(SolicitudPoda solicitudPoda)
        {
            return DeleteCityApp.Save(solicitudPoda);
        }
    }
}
