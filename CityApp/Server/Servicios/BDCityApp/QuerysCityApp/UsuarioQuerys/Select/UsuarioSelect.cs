using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys.Select
{
    public class UsuarioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Usuario> SelectCityApp = new SelectCityApp<Usuario>();

        public UsuarioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Usuario> SelectUsuarioIdCuenta(int idCuenta)
        {
            Response<Usuario> response = new Response<Usuario>();

            try
            {
                response.Data = CityAppContext.Usuarios.Where(d => d.IdCuenta == idCuenta).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
        public Response<Usuario> SelectUsuarioId(int idUsuario)
        {
            Response<Usuario> response = new Response<Usuario>();

            try
            {
                response.Data = CityAppContext.Usuarios.Where(d => d.IdUsuario == idUsuario).First();

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
