using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select
{
    public class NombreUsuarioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<string> SelectCityApp = new SelectCityApp<string>();

        public NombreUsuarioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<string> SelectNombreUsuarioNombreUsuario(string nombreUsuario)
        {
            Response<string> response = new Response<string>();

            try
            {
                response.Data = CityAppContext.Cuentas.Where(d => d.NombreUsuario == nombreUsuario).First().NombreUsuario;
                
                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<string> SelectNombreUsuarioIdCuenta(int idCuenta)
        {
            Response<string> response = new Response<string>();

            try
            {
                response.Data = CityAppContext.Cuentas.Where(d => d.IdCuenta == idCuenta).First().NombreUsuario;

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
