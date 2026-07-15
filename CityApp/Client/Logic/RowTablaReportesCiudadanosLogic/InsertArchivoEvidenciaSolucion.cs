using CityApp.Client.Services.ApiRest.EvidenciaSolucionReporteCiudadanoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.RowTablaReportesCiudadanosLogic
{
    public class InsertArchivoEvidenciaSolucion
    {
        private EvidenciaSolucionReporteCiudadanoPeticiones EvidenciaSolucionReporteCiudadanoPeticiones;

        public InsertArchivoEvidenciaSolucion(HttpClient cliente)
        {
            EvidenciaSolucionReporteCiudadanoPeticiones = new EvidenciaSolucionReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idNoticia, string token)
        {
            Response<string> response = await EvidenciaSolucionReporteCiudadanoPeticiones.agregarEvidenciaSolucionReporteCiudadano(content, idNoticia, token);
            return response;
        }
    }
}
