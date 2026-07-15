using CityApp.Client.Services.ApiRest.ColoniaPeticiones;
using CityApp.Client.Services.ApiRest.ColoniaRutaRecoleccionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewRutaRecoleccionLogic
{
    public class InsertColoniaRutaRecoleccionLogic
    {
        private ColoniaRutaRecoleccionPeticiones ColoniaRutaRecoleccionPeticiones;

        public InsertColoniaRutaRecoleccionLogic(HttpClient cliente)
        {
            ColoniaRutaRecoleccionPeticiones = new ColoniaRutaRecoleccionPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            Response<object> response = await ColoniaRutaRecoleccionPeticiones.crearColoniaRutaRecoleccion(token, coloniaRutaRecoleccion);
            return response;
        }
    }
}
