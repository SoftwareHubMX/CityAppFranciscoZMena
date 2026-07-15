using CityApp.Client.Services.ApiRest.DirectorioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarDirectorioLogic
{
    public class SelectDirectorioLogic
    {
        private DirectorioPeticiones DirectorioPeticiones;

        public SelectDirectorioLogic(HttpClient cliente)
        {
            DirectorioPeticiones = new DirectorioPeticiones(cliente);
        }

        public async Task<Response<Directorio>> Select(int idDirectorio)
        {
            Response<Directorio> response = await DirectorioPeticiones.consultarDirectorio(idDirectorio);
            return response;
        }
    }
}
