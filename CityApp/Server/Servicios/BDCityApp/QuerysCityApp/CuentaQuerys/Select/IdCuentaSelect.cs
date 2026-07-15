using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select
{
    public class IdCuentaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdCuentaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectIdCuentaNombreUsuario(string nombreUsuario)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = CityAppContext.Cuentas.Where(d => d.NombreUsuario == nombreUsuario).First().IdCuenta;

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<int> SelectIdCuentaCorreo(string correo)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = CityAppContext.Contactos.Where(d => d.Correo == correo).First().IdCuenta;

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
