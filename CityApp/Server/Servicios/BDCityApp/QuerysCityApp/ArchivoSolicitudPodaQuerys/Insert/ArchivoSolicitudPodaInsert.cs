using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys.Insert
{
    public class ArchivoSolicitudPodaInsert
    {
        private InsertCityApp<ArchivoSolicitidPoda> InsertCityApp;

        public ArchivoSolicitudPodaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoSolicitidPoda>(cityAppContext);
        }

        public Response<object> InsertArchivoSolicitudPoda(ArchivoSolicitidPoda archivoSolicitidPoda)
        {
            return InsertCityApp.Save(archivoSolicitidPoda);
        }
    }
}
