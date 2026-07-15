using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones
{
    public class ArchivoAnuncioPeticiones
    {
        private AgregarArchivoAnuncio AgregarArchivoAnuncio;
        private DescargarArchivoAnuncio DescargarArchivoAnuncio;
        private EliminarArchivoAnuncio EliminarArchivoAnuncio;

        public ArchivoAnuncioPeticiones(HttpClient cliente)
        {
            AgregarArchivoAnuncio = new AgregarArchivoAnuncio(cliente);
            DescargarArchivoAnuncio = new DescargarArchivoAnuncio(cliente);
            EliminarArchivoAnuncio = new EliminarArchivoAnuncio(cliente);
        }

        public async Task<Response<string>> agregarArchivoAnuncio(MultipartFormDataContent content, int idAnuncio, string token)
        {
            Response<string> response = await AgregarArchivoAnuncio.AgregarArchivoAnuncioAsync(content, idAnuncio, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoAnuncio(string imagen, int idAnuncio)
        {
            Response<byte[]> response = await DescargarArchivoAnuncio.DescargarArchivoAnuncioAsync(imagen, idAnuncio);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoAnuncio(string token, int idArchivoAnuncio)
        {
            Response<object> response = await EliminarArchivoAnuncio.EliminarArchivoAnuncioAsync(token, idArchivoAnuncio);
            return response;
        }
    }
}
