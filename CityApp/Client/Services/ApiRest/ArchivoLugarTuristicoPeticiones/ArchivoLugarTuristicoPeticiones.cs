using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones
{
    public class ArchivoLugarTuristicoPeticiones
    {
        private DescargarArchivoLugarTuristico DescargarArchivoLugarTuristico;
        private AgregarArchivoLugarTuristico AgregarArchivoLugarTuristico;
        private EliminarArchivoLugarTuristico EliminarArchivoLugarTuristico;

        public ArchivoLugarTuristicoPeticiones(HttpClient cliente)
        {
            DescargarArchivoLugarTuristico = new DescargarArchivoLugarTuristico(cliente);
            AgregarArchivoLugarTuristico = new AgregarArchivoLugarTuristico(cliente);
            EliminarArchivoLugarTuristico = new EliminarArchivoLugarTuristico(cliente);
        }

        public async Task<Response<string>> agregarArchivoLugarTuristico(MultipartFormDataContent content, int idLugarTuristico, string token)
        {
            Response<string> response = await AgregarArchivoLugarTuristico.AgregarArchivoLugarTuristicoAsync(content, idLugarTuristico, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoLugarTuristico(string imagen, int idLugarTuristico)
        {
            Response<byte[]> response = await DescargarArchivoLugarTuristico.DescargarArchivoLugarTuristicoAsync(imagen, idLugarTuristico);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoLugarTuristico(string token, int idArchivoLugarturistico)
        {
            Response<object> response = await EliminarArchivoLugarTuristico.EliminarArchivoLugarTuristicoAsync(token, idArchivoLugarturistico);
            return response;
        }
    }
}
