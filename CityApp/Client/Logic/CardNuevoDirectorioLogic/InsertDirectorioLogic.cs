using CityApp.Client.Services.ApiRest.DirectorioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevoDirectorioLogic
{
    public class InsertDirectorioLogic
    {
        private DirectorioPeticiones DirectorioPeticiones;

        public InsertDirectorioLogic(HttpClient cliente)
        {
            DirectorioPeticiones = new DirectorioPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, Directorio directorio)
        {
            Response<int> response = await DirectorioPeticiones.crearDirectorio(token, directorio);
            return response;
        }


    }
}
