using CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaReporteCiudadanoLogic
{
    public class UpdataEstausReporteCiudadano
    {
        private ReporteCiudadanoPeticiones ReporteCiudadanoPeticiones;

        public UpdataEstausReporteCiudadano(HttpClient cliente)
        {
            ReporteCiudadanoPeticiones = new ReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, int idEstatusReporteCiudadano, int idReporteCiudadano)
        {
            Response<object> response = await ReporteCiudadanoPeticiones.actualizarEstatusReporteCiudadano(token, idEstatusReporteCiudadano, idReporteCiudadano);
            return response;
        }
    }
}
