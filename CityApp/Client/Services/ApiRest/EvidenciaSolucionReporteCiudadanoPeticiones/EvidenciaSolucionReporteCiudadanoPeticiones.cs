using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.EvidenciaSolucionReporteCiudadanoPeticiones
{
    public class EvidenciaSolucionReporteCiudadanoPeticiones
    {
        private AgregarEvidenciaSolucionReporteCiudadano AgregarEvidenciaSolucionReporteCiudadano;
        private DescargarEvidenciaSolucionReporteCiudadano DescargarEvidenciaSolucionReporteCiudadano;
        private EliminarEvidenciaSolucionReporteCiudadano EliminarEvidenciaSolucionReporteCiudadano;

        public EvidenciaSolucionReporteCiudadanoPeticiones(HttpClient cliente)
        {
            AgregarEvidenciaSolucionReporteCiudadano = new AgregarEvidenciaSolucionReporteCiudadano(cliente);
            DescargarEvidenciaSolucionReporteCiudadano = new DescargarEvidenciaSolucionReporteCiudadano(cliente);
            EliminarEvidenciaSolucionReporteCiudadano = new EliminarEvidenciaSolucionReporteCiudadano(cliente);
        }

        public async Task<Response<string>> agregarEvidenciaSolucionReporteCiudadano(MultipartFormDataContent content, int idReporteCiudadano, string token)
        {
            Response<string> response = await AgregarEvidenciaSolucionReporteCiudadano.AgregarEvidenciaSolucionReporteCiudadanoAsync(content, idReporteCiudadano, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarEvidenciaSolucionReporteCiudadano(string imagen, string token, int idReporteCiudadano)
        {
            Response<byte[]> response = await DescargarEvidenciaSolucionReporteCiudadano.DescargarEvidenciaSolucionReporteCiudadanoAsync(imagen, token, idReporteCiudadano);
            return response;
        }

        public async Task<Response<object>> eliminarEvidenciaSolucionReporteCiudadano(string token, int idEvidenciaSolucionReporteCiudadano)
        {
            Response<object> response = await EliminarEvidenciaSolucionReporteCiudadano.EliminarEvidenciaSolucionReporteCiudadanoAsync(token, idEvidenciaSolucionReporteCiudadano);
            return response;
        }
    }
}
