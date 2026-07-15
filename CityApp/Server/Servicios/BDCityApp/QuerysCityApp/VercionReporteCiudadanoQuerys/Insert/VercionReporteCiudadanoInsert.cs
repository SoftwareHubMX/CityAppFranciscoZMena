using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys.Insert
{
    public class VercionReporteCiudadanoInsert
    {
        private InsertCityApp<VercionReporteCiudadano> InsertCityApp;

        public VercionReporteCiudadanoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<VercionReporteCiudadano>(cityAppContext);
        }

        public Response<object> InsertVercionReporteCiudadano(VercionReporteCiudadano vercionReporteCiudadano)
        {
            return InsertCityApp.Save(vercionReporteCiudadano);
        }
    }
}
