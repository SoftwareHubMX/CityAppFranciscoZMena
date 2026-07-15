using CityApp.Client.Services.ApiRest.ArchivoAgendaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarAgenda
{
    public class DeleteArchivoAgenda
    {
        private ArchivoAgendaPeticiones ArchivoAgendaPeticiones;

        public DeleteArchivoAgenda(HttpClient cliente)
        {
            ArchivoAgendaPeticiones = new ArchivoAgendaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idArchivoAgenda)
        {
            Response<object> response = await ArchivoAgendaPeticiones.eliminarArchivoAgenda(token, idArchivoAgenda);
            return response;
        }
    }
}
