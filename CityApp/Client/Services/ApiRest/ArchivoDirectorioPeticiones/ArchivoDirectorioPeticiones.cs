using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones
{
    public class ArchivoDirectorioPeticiones
    {
        private AgregarArchivoDirectorio AgregarArchivoDirectorio;
        private DescargarArchivoDirectorio DescargarArchivoDirectorio;
        private EliminarArchivoDirectorio EliminarArchivoDirectorio;

        public ArchivoDirectorioPeticiones(HttpClient cliente)
        {
            AgregarArchivoDirectorio = new AgregarArchivoDirectorio(cliente);
            DescargarArchivoDirectorio = new DescargarArchivoDirectorio(cliente);
            EliminarArchivoDirectorio = new EliminarArchivoDirectorio(cliente);
        }

        public async Task<Response<string>> agregarArchivoDirectorio(MultipartFormDataContent content, int idDirectorio, string token)
        {
            Response<string> response = await AgregarArchivoDirectorio.AgregarArchivoDirectorioAsync(content, idDirectorio, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoDirectorio(string imagen, int idDirectorio)
        {
            Response<byte[]> response = await DescargarArchivoDirectorio.DescargarArchivoDirectorioAsync(imagen, idDirectorio);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoDirectorio(string token, int idArchivoDirectorio)
        {
            Response<object> response = await EliminarArchivoDirectorio.EliminarArchivoDirectorioAsync(token, idArchivoDirectorio);
            return response;
        }
    }
}
