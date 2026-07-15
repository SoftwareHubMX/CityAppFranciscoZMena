using CityApp.Client.Services.ApiRest.RolPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaCuentasLogic
{
    public class SelectRolesLogic
    {
        private RolPeticiones RolPeticiones;

        public SelectRolesLogic(HttpClient cliente)
        {
            RolPeticiones = new RolPeticiones(cliente);
        }

        public async Task<Response<List<Rol>>> SelectAll()
        {
            Response<List<Rol>> response = await RolPeticiones.consultarRoles();
            return response;
        }
    }
}
