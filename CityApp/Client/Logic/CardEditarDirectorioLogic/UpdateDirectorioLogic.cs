using CityApp.Client.Services.ApiRest.DirectorioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarDirectorioLogic
{
    public class UpdateDirectorioLogic
    {
        private DirectorioPeticiones DirectorioPeticiones;

        public UpdateDirectorioLogic(HttpClient cliente)
        {
            DirectorioPeticiones = new DirectorioPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, Directorio directorio)
        {
            Response<object> response = await DirectorioPeticiones.editarDirectorio(token, directorio);
            return response;
        }
    }
}
