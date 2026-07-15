using CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones;
using CityApp.Client.Services.ApiRest.RutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalDetallesColoniasRutaLogic
{
    public class SelectColoniasRutaRecoleccionLogic
    {
        private RutaRecoleccionPeticiones RutaRecoleccionPeticiones;

        public SelectColoniasRutaRecoleccionLogic(HttpClient cliente)
        {
            RutaRecoleccionPeticiones = new RutaRecoleccionPeticiones(cliente);
        }

        public async Task<Response<RutaRecoleccion>> SelectAll(string token, int idRutaRecoleccion)
        {
            Response<RutaRecoleccion> response = await RutaRecoleccionPeticiones.consultarRutaRecoleccion(token, idRutaRecoleccion);
            return response;
        }
    }
}
