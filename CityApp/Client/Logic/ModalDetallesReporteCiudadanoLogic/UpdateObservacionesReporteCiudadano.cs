using CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalDetallesReporteCiudadanoLogic
{
    public class UpdateObservacionesReporteCiudadano
    {
        private ReporteCiudadanoPeticiones ReporteCiudadanoPeticiones;

        public UpdateObservacionesReporteCiudadano(HttpClient cliente)
        {
            ReporteCiudadanoPeticiones = new ReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, string observaciones, int idReporteCiudadano)
        {
            Response<object> response = await ReporteCiudadanoPeticiones.actualizacionObservacionesReporte(token, observaciones, idReporteCiudadano);
            return response;
        }
    }
}
