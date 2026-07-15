using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoDirectorioPeticiones
{
    public class TipoDirectorioPeticiones
    {
        private ConsultarTiposDirectorio ConsultarTiposDirectorio;

        public TipoDirectorioPeticiones(HttpClient cliente)
        {
            ConsultarTiposDirectorio = new ConsultarTiposDirectorio(cliente);
        }

        public async Task<Response<List<TipoDirectorio>>> consultarTiposDirectorio()
        {
            Response<List<TipoDirectorio>> response = await ConsultarTiposDirectorio.ConsultarTiposDirectorioAsync();
            return response;
        }
    }
}
