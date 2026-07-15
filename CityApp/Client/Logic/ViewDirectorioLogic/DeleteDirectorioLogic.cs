using CityApp.Client.Services.ApiRest.DirectorioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ViewDirectorioLogic
{
    public class DeleteDirectorioLogic
    {
        private DirectorioPeticiones DirectorioPeticiones;

        public DeleteDirectorioLogic(HttpClient cliente)
        {
            DirectorioPeticiones = new DirectorioPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idDirectorio)
        {
            Response<object> response = await DirectorioPeticiones.eliminarDirectorio(token, idDirectorio);
            return response;
        }
    }
}
