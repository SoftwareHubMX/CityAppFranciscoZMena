using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Update
{
    public class SolicitudPodaUpdate
    {
        private UpdateCityApp<SolicitudPoda> UpdateCityApp;

        public SolicitudPodaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<SolicitudPoda>(cityAppContext);
        }
        public Response<object> UpdateSolicitudPoda(SolicitudPoda solicitudPoda)
        {
            return UpdateCityApp.Save(solicitudPoda);
        }
    }
}
