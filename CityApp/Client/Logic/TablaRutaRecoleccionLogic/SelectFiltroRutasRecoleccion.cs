using CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaRutaRecoleccionLogic
{
    public class SelectFiltroRutasRecoleccion
    {
        private RutaRecoleccionPeticiones RutaRecoleccionPeticiones;

        public SelectFiltroRutasRecoleccion(HttpClient cliente)
        {
            RutaRecoleccionPeticiones = new RutaRecoleccionPeticiones(cliente);
        }

        public async Task<Response<List<RutaRecoleccion>>> SelectAll(string token, FiltroRutaRecoleccion filtroRutaRecoleccion)
        {
            Response<List<RutaRecoleccion>> response = await RutaRecoleccionPeticiones.consultarFiltroRutaRecoleccion( token, filtroRutaRecoleccion);
            return response;
        }
    }
}
