using CityApp.Client.Services.ApiRest.NormatividadPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaNormatividadLogic
{
    public class DeleteNormatividad
    {
        private NormatividadPeticiones NormatividadPeticiones;

        public DeleteNormatividad(HttpClient cliente)
        {
            NormatividadPeticiones = new NormatividadPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idNormatividad)
        {
            Response<object> response = await NormatividadPeticiones.eliminarNormatividad(token, idNormatividad);
            return response;
        }
    }
}
