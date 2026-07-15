using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Delete
{
    public class EvidenciaSolucionReporteCiudadanoDelete
    {
        private DeleteCityApp<EvidenciaSolucionReporteCiudadano> DeleteCityApp;

        public EvidenciaSolucionReporteCiudadanoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<EvidenciaSolucionReporteCiudadano>(cityAppContext);
        }

        public Response<object> DeleteEvidenciaReporteCiudadano(EvidenciaSolucionReporteCiudadano evidenciaSolucionReporteCiudadano)
        {
            return DeleteCityApp.Save(evidenciaSolucionReporteCiudadano);
        }
    }
}
