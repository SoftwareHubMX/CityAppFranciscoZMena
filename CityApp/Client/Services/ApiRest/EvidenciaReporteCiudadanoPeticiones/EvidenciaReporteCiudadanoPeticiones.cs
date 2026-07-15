using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.EvidenciaReporteCiudadanoPeticiones
{
    public class EvidenciaReporteCiudadanoPeticiones
    {
        private AgregarEvidenciaReporteCiudadano AgregarEvidenciaReporteCiudadano;
        private DescargarEvidenciaReporteCiudadano DescargarEvidenciaReporteCiudadano;
        private EliminarEvidenciaReporteCiudadano EliminarEvidenciaReporteCiudadano;

        public EvidenciaReporteCiudadanoPeticiones(HttpClient cliente)
        {
            AgregarEvidenciaReporteCiudadano = new AgregarEvidenciaReporteCiudadano(cliente);
            DescargarEvidenciaReporteCiudadano = new DescargarEvidenciaReporteCiudadano(cliente);
            EliminarEvidenciaReporteCiudadano = new EliminarEvidenciaReporteCiudadano(cliente);
        }

        public async Task<Response<string>> agregarEvidenciaReporteCiudadano(MultipartFormDataContent content, int idReporteCiudadano, string token)
        {
            Response<string> response = await AgregarEvidenciaReporteCiudadano.AgregarEvidenciaReporteCiudadanoAsync(content, idReporteCiudadano, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarEvidenciaReporteCiudadano(string imagen, string token, int idVercionReporte)
        {
            Response<byte[]> response = await DescargarEvidenciaReporteCiudadano.DescargarEvidenciaReporteCiudadanoAsync(imagen, token, idVercionReporte);
            return response;
        }

        public async Task<Response<object>> eliminarEvidenciaReporteCiudadano(string token, int idEvidenciaReporteCiudadano)
        {
            Response<object> response = await EliminarEvidenciaReporteCiudadano.EliminarEvidenciaReporteCiudadanoAsync(token, idEvidenciaReporteCiudadano);
            return response;
        }
    }
}
