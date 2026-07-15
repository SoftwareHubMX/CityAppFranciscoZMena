using CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditRutaRecoleccionLogic
{
    public class SelectRutaRecoleccionLogic
    {
        private RutaRecoleccionPeticiones RutaRecoleccionPeticiones;

        public SelectRutaRecoleccionLogic(HttpClient cliente)
        {
            RutaRecoleccionPeticiones = new RutaRecoleccionPeticiones(cliente);
        }

        public async Task<Response<RutaRecoleccion>> Select(string token, int idRutaRecoleccion)
        {
            Response<RutaRecoleccion> response = await RutaRecoleccionPeticiones.consultarRutaRecoleccion(token, idRutaRecoleccion);
            return response;
        }
    }
}
