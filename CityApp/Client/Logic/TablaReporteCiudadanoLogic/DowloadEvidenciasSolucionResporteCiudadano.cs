using CityApp.Client.Services.ApiRest.EvidenciaSolucionReporteCiudadanoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaReporteCiudadanoLogic
{
    public class DowloadEvidenciasSolucionResporteCiudadano
    {
        private EvidenciaSolucionReporteCiudadanoPeticiones EvidenciaSolucionReporteCiudadanoPeticiones;

        public DowloadEvidenciasSolucionResporteCiudadano(HttpClient cliente)
        {
            EvidenciaSolucionReporteCiudadanoPeticiones = new EvidenciaSolucionReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Dowload(string imagen, string token, int idReporteCiudadano)
        {
            Response<byte[]> response = await EvidenciaSolucionReporteCiudadanoPeticiones.descargarEvidenciaSolucionReporteCiudadano(imagen, token, idReporteCiudadano);
            return response;
        }
    }
}
