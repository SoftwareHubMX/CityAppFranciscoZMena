using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoReporteCiudadanoLogic
{
    public class ConsultarTiposReporteCiudadanoLogic
    {
        private TipoReporteCiudadanoQuerys TipoReporteCiudadanoQuerys;

        public ConsultarTiposReporteCiudadanoLogic(CityAppContext cityAppContext)
        {
            TipoReporteCiudadanoQuerys = new TipoReporteCiudadanoQuerys(cityAppContext);
        }

        public Response<List<TipoReporteCiudadano>> Consultar()
        {
            Response<List<TipoReporteCiudadano>> response = new Response<List<TipoReporteCiudadano>>();

            Response<IEnumerable<TipoReporteCiudadano>> responseTiposReporteCiudadano = TipoReporteCiudadanoQuerys.SelectTiposReporteCiudadano();
            response.Status = responseTiposReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTiposReporteCiudadano.Data.ToList();
            }

            return response;
        }
    }
}
