using CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditRutaRecoleccionLogic
{
    public class DeleteColoniaRutaRecoleccionLogic
    {
        private ColoniaRutaRecoleccionPeticiones ColoniaRutaRecoleccionPeticiones;

        public DeleteColoniaRutaRecoleccionLogic(HttpClient cliente)
        {
            ColoniaRutaRecoleccionPeticiones = new ColoniaRutaRecoleccionPeticiones(cliente);
        }
        
        public async Task<Response<object>> Delete (string token, ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            Response<object> response = await ColoniaRutaRecoleccionPeticiones.eliminarColoniaRutaRecoleccion(token, coloniaRutaRecoleccion);
            return response;
        }
    }
}
