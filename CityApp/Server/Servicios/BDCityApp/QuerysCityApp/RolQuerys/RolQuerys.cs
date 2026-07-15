using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys
{
    public class RolQuerys
    {
        private RolSelect RolSelect;
        private RolesSelect RolesSelect;

        public RolQuerys(CityAppContext cityAppContext)
        {
            RolSelect = new RolSelect(cityAppContext);
            RolesSelect = new RolesSelect(cityAppContext);
        }

        //select
        public Response<Rol> SelectRolIdRol(int idRol)
        {
            return RolSelect.SelectRolIdRol(idRol);
        }

        public Response<IEnumerable<Rol>> SelectRoles()
        {
            return RolesSelect.SelectRoles();   
        }
    }
}
