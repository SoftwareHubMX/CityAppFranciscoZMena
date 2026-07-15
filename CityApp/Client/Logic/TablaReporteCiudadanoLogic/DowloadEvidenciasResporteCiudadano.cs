using CityApp.Client.Services.ApiRest.EvidenciaReporteCiudadanoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaReporteCiudadanoLogic
{
    public class DowloadEvidenciasResporteCiudadano
    {
        private EvidenciaReporteCiudadanoPeticiones EvidenciaReporteCiudadanoPeticiones;

        public DowloadEvidenciasResporteCiudadano(HttpClient cliente)
        {
            EvidenciaReporteCiudadanoPeticiones = new EvidenciaReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Dowload(string imagen, string token, int idVercionReporte)
        {
            Response<byte[]> response = await EvidenciaReporteCiudadanoPeticiones.descargarEvidenciaReporteCiudadano(imagen, token,idVercionReporte);
            return response;
        }
    }
}
