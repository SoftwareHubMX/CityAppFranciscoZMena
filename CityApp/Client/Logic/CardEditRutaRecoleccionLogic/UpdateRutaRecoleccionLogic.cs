using CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaRutaRecoleccionLogic
{
    public class UpdateRutaRecoleccionLogic
    {
        private RutaRecoleccionPeticiones RutaRecoleccionPeticiones;

        public UpdateRutaRecoleccionLogic(HttpClient cliente)
        {
            RutaRecoleccionPeticiones = new RutaRecoleccionPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, RutaRecoleccion rutaRecoleccion)
        {
            Response<object> response = await RutaRecoleccionPeticiones.actualizarRutaRecoleccion(token, rutaRecoleccion);
            return response;
        }
    }
}
