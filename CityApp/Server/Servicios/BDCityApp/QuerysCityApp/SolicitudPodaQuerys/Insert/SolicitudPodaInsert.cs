using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys.Insert
{
    public class SolicitudPodaInsert
    {
        private InsertCityApp<SolicitudPoda> InsertCityApp;

        public SolicitudPodaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<SolicitudPoda>(cityAppContext);
        }

        public Response<object> InsertSolicitudPoda(SolicitudPoda solicitudPoda)
        {
            return InsertCityApp.Save(solicitudPoda);
        }
    }
}
