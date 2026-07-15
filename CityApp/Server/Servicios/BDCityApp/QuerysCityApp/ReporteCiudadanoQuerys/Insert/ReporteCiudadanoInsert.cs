using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Insert
{
    public class ReporteCiudadanoInsert
    {
        private InsertCityApp<ReporteCiudadano> InsertCityApp;

        public ReporteCiudadanoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ReporteCiudadano>(cityAppContext);
        }

        public Response<object> InsertReporteCiudadano(ReporteCiudadano reporteCiudadano)
        {
            return InsertCityApp.Save(reporteCiudadano);
        }
    }
}
