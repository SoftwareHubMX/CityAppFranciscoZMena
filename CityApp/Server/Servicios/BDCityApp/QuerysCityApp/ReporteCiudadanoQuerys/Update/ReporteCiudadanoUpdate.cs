using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Update
{
    public class ReporteCiudadanoUpdate
    {
        private UpdateCityApp<ReporteCiudadano> UpdateCityApp;

        public ReporteCiudadanoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<ReporteCiudadano>(cityAppContext);
        }

        public Response<object> UpdateReporteCiudadano(ReporteCiudadano reporteCiudadano)
        {
            return UpdateCityApp.Save(reporteCiudadano);
        }
    }
}
