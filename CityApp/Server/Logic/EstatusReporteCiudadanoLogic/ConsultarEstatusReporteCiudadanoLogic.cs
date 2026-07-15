using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusReporteCiudadanoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EstatusReporteCiudadanoLogic
{
    public class ConsultarEstatusReporteCiudadanoLogic
    {
        private EstatusReporteCiudadanoQuerys EstatusReporteCiudadanoQuerys;

        public ConsultarEstatusReporteCiudadanoLogic(CityAppContext cityAppContext)
        {
            EstatusReporteCiudadanoQuerys = new EstatusReporteCiudadanoQuerys(cityAppContext);
        }

        public Response<List<EstatusReporteCiudadano>> Consultar()
        {
            Response<List<EstatusReporteCiudadano>> response = new Response<List<EstatusReporteCiudadano>>();

            Response<IEnumerable<EstatusReporteCiudadano>> responseEstatusReporteCiudadano = EstatusReporteCiudadanoQuerys.SelectEstatusReporteCiudadano();
            response.Status = responseEstatusReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseEstatusReporteCiudadano.Data.ToList();
            }

            return response;
        }
    }
}
