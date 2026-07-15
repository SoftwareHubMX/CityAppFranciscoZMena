using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Delete
{
    public class EvidenciaReporteCiudadanoDelete
    {
        private DeleteCityApp<EvidenciaReporteCiudadano> DeleteCityApp;

        public EvidenciaReporteCiudadanoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<EvidenciaReporteCiudadano>(cityAppContext);
        }

        public Response<object> DeleteEvidenciaReporteCiudadano(EvidenciaReporteCiudadano evidenciaReporteCiudadano)
        {
            return DeleteCityApp.Save(evidenciaReporteCiudadano);
        }
    }
}
