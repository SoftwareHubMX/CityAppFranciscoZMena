using CityApp.Client.Services.ApiRest.NormatividadPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaNormatividadLogic
{
    public class InsertNormatividadLogic
    {
        private NormatividadPeticiones NormatividadPeticiones;

        public InsertNormatividadLogic(HttpClient cliente)
        {
            NormatividadPeticiones = new NormatividadPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, Normatividad Normatividad)
        {
            Response<object> response = await NormatividadPeticiones.crearNormatividad(token, Normatividad);
            return response;
        }
    }
}
