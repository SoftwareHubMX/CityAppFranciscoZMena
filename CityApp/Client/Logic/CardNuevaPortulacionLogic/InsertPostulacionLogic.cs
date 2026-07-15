using CityApp.Client.Services.ApiRest.PostulacionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaPortulacionLogic
{
    public class InsertPostulacionLogic
    {
        private PostulacionPeticiones PostulacionPeticiones;

        public InsertPostulacionLogic(HttpClient cliente)
        {
            PostulacionPeticiones = new PostulacionPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, Postulacion postulacion)
        {
            Response<object> response = await PostulacionPeticiones.crearPostulacion(token, postulacion);
            return response;
        }
    }
}
