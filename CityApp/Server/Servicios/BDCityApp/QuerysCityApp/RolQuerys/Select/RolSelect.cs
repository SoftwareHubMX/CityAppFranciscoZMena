using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RolQuerys.Select
{
    public class RolSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Rol> SelectCityApp = new SelectCityApp<Rol>();

        public RolSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Rol> SelectRolIdRol(int idRol)
        {
            Response<Rol> response = new Response<Rol>();

            try
            {
                response.Data = CityAppContext.Roles.Where(d => d.IdRol == idRol).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
