using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Insert
{
    public class EvidenciaReporteCiudadanoInsert
    {
        private InsertCityApp<EvidenciaReporteCiudadano> InsertCityApp;

        public EvidenciaReporteCiudadanoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<EvidenciaReporteCiudadano>(cityAppContext);
        }

        public Response<object> InsertEvidenciaReporteCiudadano(EvidenciaReporteCiudadano evidenciaReporteCiudadano)
        {
            return InsertCityApp.Save(evidenciaReporteCiudadano);
        }
    }
}
