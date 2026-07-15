using CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewRutaRecoleccionLogic
{
    public class InsertRutaRecoleccionLogic
    {
        private RutaRecoleccionPeticiones RutaRecoleccionPeticiones;

        public InsertRutaRecoleccionLogic(HttpClient cliente)
        {
            RutaRecoleccionPeticiones = new RutaRecoleccionPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, RutaRecoleccion rutaRecoleccion)
        {
            Response<int> response = await RutaRecoleccionPeticiones.crearRutaRecoleccion(token, rutaRecoleccion);
            return response;
        }
    }
}
