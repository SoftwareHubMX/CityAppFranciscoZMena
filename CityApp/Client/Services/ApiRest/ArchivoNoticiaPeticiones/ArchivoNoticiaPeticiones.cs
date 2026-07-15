using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoNoticiaPeticiones
{
    public class ArchivoNoticiaPeticiones
    {
        private AgregarArchivoNoticia AgregarArchivoNoticia;
        private DescargarArchivoNoticia DescargarArchivoNoticia;
        private EliminarArchivoNoticia EliminarArchivoNoticia;

        public ArchivoNoticiaPeticiones(HttpClient cliente)
        {
            AgregarArchivoNoticia = new AgregarArchivoNoticia(cliente);
            DescargarArchivoNoticia = new DescargarArchivoNoticia(cliente);
            EliminarArchivoNoticia = new EliminarArchivoNoticia(cliente);
        }

        public async Task<Response<string>> agregarArchivoNoticia(MultipartFormDataContent content, int idNoticia, string token)
        {
            Response<string> response = await AgregarArchivoNoticia.AgregarArchivoNoticiaAsync(content, idNoticia, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoNoticia(string imagen, int idNotocia)
        {
            Response<byte[]> response = await DescargarArchivoNoticia.DescargarArchivoNoticiaAsync(imagen, idNotocia);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoNoticia(string token, int idArchivoNoticia)
        {
            Response<object> response = await EliminarArchivoNoticia.EliminarArchivoNoticiaAsync(token, idArchivoNoticia);
            return response;
        }
    }
}
