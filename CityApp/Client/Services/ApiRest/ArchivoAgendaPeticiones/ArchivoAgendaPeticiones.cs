using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoAgendaPeticiones
{
    public class ArchivoAgendaPeticiones
    {
        private AgregarArchivoAgenda AgregarArchivoAgenda;
        private DescargarArchivoAgenda DescargarArchivoAgenda;
        private EliminarArchivoAgenda EliminarArchivoAgenda;

        public ArchivoAgendaPeticiones(HttpClient cliente)
        {
            AgregarArchivoAgenda = new AgregarArchivoAgenda(cliente);
            DescargarArchivoAgenda = new DescargarArchivoAgenda(cliente);
            EliminarArchivoAgenda = new EliminarArchivoAgenda(cliente);
        }

        public async Task<Response<string>> agregarArchivoAgenda(MultipartFormDataContent content, int idAgenda, string token)
        {
            Response<string> response = await AgregarArchivoAgenda.AgregarArchivoAgendaAsync(content, idAgenda, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoAgenda(string imagen, int idNotocia)
        {
            Response<byte[]> response = await DescargarArchivoAgenda.DescargarArchivoAgendaAsync(imagen, idNotocia);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoAgenda(string token, int idArchivoAgenda)
        {
            Response<object> response = await EliminarArchivoAgenda.EliminarArchivoAgendaAsync(token, idArchivoAgenda);
            return response;
        }
    }
}
