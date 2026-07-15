using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RolLogic
{
    public class ConsultarRolesLogic
    {
        private RolQuerys RolQuerys;

        public ConsultarRolesLogic(CityAppContext cityAppContext)
        {
            RolQuerys = new RolQuerys(cityAppContext);
        }

        public Response<List<Rol>> Consultar()
        {
            Response<List<Rol>> response = new Response<List<Rol>>();

            Response<IEnumerable<Rol>> responseRol = RolQuerys.SelectRoles();
            response.Status = responseRol.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseRol.Data.ToList();
            }
            return response;
        }
    }
}
