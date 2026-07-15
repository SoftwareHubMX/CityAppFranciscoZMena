using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.UsuarioLogic
{
    public class ConsultarUsuarioLogic
    {
        private UsuarioQuerys UsuarioQuerys;

        private int IdCuenta;

        public ConsultarUsuarioLogic(CityAppContext cityAppContext, int idCuenta)
        {
            UsuarioQuerys = new UsuarioQuerys(cityAppContext);

            IdCuenta = idCuenta;
        }

        public Response<Usuario> Consultar()
        {
            Response<Usuario> response = new Response<Usuario>();

            response = UsuarioQuerys.SelectUsuarioIdCuenta(IdCuenta);

            return response;
        }
    }
}
