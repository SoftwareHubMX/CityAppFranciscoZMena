using CityApp.Client.Services.ApiRest.ArchivoAgendaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaAgendaLogic
{
    public class InsertArchivoAgenda
    {
        private ArchivoAgendaPeticiones ArchivoAgendaPeticiones;

        public InsertArchivoAgenda(HttpClient cliente)
        {
            ArchivoAgendaPeticiones = new ArchivoAgendaPeticiones(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idAgenda, string token)
        {
            Response<string> response = await ArchivoAgendaPeticiones.agregarArchivoAgenda(content, idAgenda, token);
            return response;
        }
    }
}
