using CityApp.Client.Services.ApiRest.DirectorioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ViewDirectorioLogic
{
    public class SelectDirectoriosLogic
    {
        private DirectorioPeticiones DirectorioPeticiones;

        public SelectDirectoriosLogic(HttpClient cliente)
        {
            DirectorioPeticiones = new DirectorioPeticiones(cliente);
        }

        public async Task<Response<List<Directorio>>> SelectAll(string token,FiltroDirectorio filtroDirectorio)
        {
            Response<List<Directorio>> response = await DirectorioPeticiones.consultarDirectorios(token, filtroDirectorio);
            return response;
        }
    }
}
