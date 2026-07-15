using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys.Select
{
    public class RolesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp <Rol> SelectCityApp = new SelectCityApp<Rol> ();

        public RolesSelect (CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Rol>> SelectRoles()
        {
            Response<IEnumerable<Rol>> response = new Response<IEnumerable<Rol>> ();
            try
            {
                response.Data = CityAppContext.Roles;
                response.Status = SelectCityApp.ValidarLista(response.Data);    
            }
            catch (Exception ex)
            {

                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }
    }
}
