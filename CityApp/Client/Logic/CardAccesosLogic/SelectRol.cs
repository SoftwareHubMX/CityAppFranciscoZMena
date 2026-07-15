using CityApp.Client.Services.ApiRest.RolPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardAccesosLogic
{
    public class SelectRol
    {
        private RolPeticiones RolPeticiones;

        public SelectRol(HttpClient cliente)
        {
            RolPeticiones = new RolPeticiones(cliente);
        }

        public async Task<Response<Rol>> Select(int idRol)
        {
            Response<Rol> response = await RolPeticiones.consultarRol(idRol);
            return response;
        }
    }
}
