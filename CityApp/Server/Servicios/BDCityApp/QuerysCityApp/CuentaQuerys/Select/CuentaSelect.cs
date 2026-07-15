using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select
{
    public class CuentaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Cuenta> SelectCityApp = new SelectCityApp<Cuenta>();

        public CuentaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Cuenta> SelectCuentaIdCuenta(int idCuenta)
        {
            Response<Cuenta> response = new Response<Cuenta>();

            try
            {
                response.Data = CityAppContext.Cuentas.Where(d => d.IdCuenta == idCuenta).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Cuenta> SelectCuentaCorreo(string correo)
        {
            Response<Cuenta> response = new Response<Cuenta>();

            try
            {
                response.Data = CityAppContext.Cuentas.Where(d => d.Contacto.Correo == correo).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Cuenta> SelectCuentaIdCuentaPassword(int idCuenta, string password)
        {
            Response<Cuenta> response = new Response<Cuenta>();

            try
            {
                response.Data = (from data in CityAppContext.Cuentas
                                where data.IdCuenta == idCuenta
                                && data.Password == password
                                && data.EstatusActivo == true
                                select new Cuenta()
                                {
                                    IdCuenta = data.IdCuenta,
                                    NombreUsuario = data.NombreUsuario,
                                    EstatusCuenta = data.EstatusCuenta,
                                    Rol = data.Rol,
                                }).First();

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
