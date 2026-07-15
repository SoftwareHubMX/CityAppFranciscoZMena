using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Insert
{
    public class EvidenciaSolucionReporteCiudadanoInsert
    {
        private InsertCityApp<EvidenciaSolucionReporteCiudadano> InsertCityApp;

        public EvidenciaSolucionReporteCiudadanoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<EvidenciaSolucionReporteCiudadano>(cityAppContext);
        }

        public Response<object> InsertEvidenciaReporteCiudadano(EvidenciaSolucionReporteCiudadano evidenciaSolucionReporteCiudadano)
        {
            return InsertCityApp.Save(evidenciaSolucionReporteCiudadano);
        }
    }
}
