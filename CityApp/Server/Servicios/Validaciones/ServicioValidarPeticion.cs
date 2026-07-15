using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Validaciones
{
    public class ServicioValidarPeticion
    {
        private TokenLoginQuerys TokenLoginQuerys;
        private CuentaQuerys CuentaQuerys;

        public ServicioValidarPeticion(CityAppContext cityAppContext)
        {
            TokenLoginQuerys = new TokenLoginQuerys(cityAppContext);
            CuentaQuerys = new CuentaQuerys(cityAppContext);
        }

        public Response<int> ValidarAuth(string token)
        {
            Response<int> response = new Response<int>();

            Response<TokenLogin> responseTokenLogin = TokenLoginQuerys.SelectTokenLoginToken(token);
            response.Status = responseTokenLogin.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTokenLogin.Data.IdCuenta;
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Mensaje = "El token no es valido";
            }

            return response;
        }

        public Response<int> ValidarAuthAdmin(string token)
        {
            Response<int> response = new Response<int>();

            Response<TokenLogin> responseTokenLogin = TokenLoginQuerys.SelectTokenLoginToken(token);
            response.Status = responseTokenLogin.Status;
            if (response.Status.Exito == 1)
            {
                Response<int> responseIdRol = CuentaQuerys.SelectIdRolIdCuenta(responseTokenLogin.Data.IdCuenta);
                response.Status = responseIdRol.Status;
                if (response.Status.Exito == 1 && responseIdRol.Data != 2)
                {
                    response.Data = responseTokenLogin.Data.IdCuenta;
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "El token no es valido para esto";
                }
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Mensaje = "El token no es valido";
            }

            return response;
        }
    }
}
