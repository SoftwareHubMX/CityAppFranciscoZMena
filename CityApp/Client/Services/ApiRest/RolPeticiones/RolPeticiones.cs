
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.RolPeticiones
{
    public class RolPeticiones
    {
        private ConsultarRol ConsultarRol;
        private ConsultarRoles ConsultarRoles;  

        public RolPeticiones(HttpClient cliente)
        {
            ConsultarRol = new ConsultarRol(cliente);
            ConsultarRoles = new ConsultarRoles(cliente);
        }

        public async Task<Response<Rol>> consultarRol(int idRol)
        {
            Response<Rol> response = await ConsultarRol.ConsultarRolAsync(idRol);
            return response;
        }

        public async Task<Response<List<Rol>>> consultarRoles()
        {
            Response<List<Rol>> response = await ConsultarRoles.ConsultarRolesAsync();
            return response;
        }
        
    }
}
