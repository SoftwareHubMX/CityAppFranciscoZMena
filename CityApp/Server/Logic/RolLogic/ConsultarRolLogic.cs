using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RolLogic
{
    public class ConsultarRolLogic
    {
        private RolQuerys RolQuerys;
        private int IdRol = 0;

        public ConsultarRolLogic(CityAppContext cityAppContext, int idRol)
        {
            RolQuerys = new RolQuerys(cityAppContext);
            IdRol = idRol;
        }

        public Response<Rol> Consultar()
        {
            return RolQuerys.SelectRolIdRol(IdRol);
        }
    }
}
