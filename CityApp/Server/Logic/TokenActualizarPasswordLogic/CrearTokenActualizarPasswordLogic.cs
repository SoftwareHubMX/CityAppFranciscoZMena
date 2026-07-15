using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TokenActualizarPasswordLogic
{
    public class CrearTokenActualizarPasswordLogic
    {
        private TokenActualizarPasswordQuerys TokenActualizarPasswordQuerys;
        private CuentaQuerys CuentaQuerys;

        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private string Correo;
        private Cuenta Cuenta;

        public CrearTokenActualizarPasswordLogic(CityAppContext cityAppContext, string correo)
        {
            TokenActualizarPasswordQuerys = new TokenActualizarPasswordQuerys(cityAppContext);
            CuentaQuerys = new CuentaQuerys(cityAppContext);

            Correo = correo;
        }

        public Response<object> Crear()
        {
            Response<object> response = new Response<object>();

            Response<Cuenta> responseCuenta = CuentaQuerys.SelectCuentaCorreo(Correo);
            response.Status = responseCuenta.Status;
            if (response.Status.Exito == 1)
            {
                Cuenta = responseCuenta.Data;
                response = GenerarTokenCorreo();
                if (response.Status.Exito == 1)
                {
                    response = EnviarMail();
                }
            }

            return response;
        }

        private Response<object> GenerarTokenCorreo()
        {
            Response<object> response = new Response<object>();

            Response<string> responseToken = new Response<string>();
            string token = "";
            do
            {
                GeneradorTokens generadorTokens = GeneradorTokens.Instancia();
                token = generadorTokens.GetToken(45);
                responseToken = TokenActualizarPasswordQuerys.SelectTokenToken(token);
            } while (responseToken.Status.Exito == 1);

            response.Status = responseToken.Status;
            if (response.Status.Exito == 2)
            {
                Response<TokenActualizarPassword> responseTokenActualizarPassword = TokenActualizarPasswordQuerys.SelectTokenActualizarPasswordIdCuenta(Cuenta.IdCuenta);
                response.Status = responseTokenActualizarPassword.Status;
                if (response.Status.Exito == 1)
                {
                    Cuenta.TokenActualizarPassword = responseTokenActualizarPassword.Data;
                    Cuenta.TokenActualizarPassword.Token = token;
                    response = TokenActualizarPasswordQuerys.UpdateTokenActualizarPassword(Cuenta.TokenActualizarPassword);
                }
                else if (response.Status.Exito == 2)
                {
                    Cuenta.TokenActualizarPassword = new TokenActualizarPassword()
                    {
                        Token = token,
                        IdCuenta = Cuenta.IdCuenta,
                    };
                    response = TokenActualizarPasswordQuerys.InsertTokenActualizarPassword(Cuenta.TokenActualizarPassword);
                }
            }

            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            string data = CorreoCrearTokenRecuperarPassword.GetCorreo(Cuenta.TokenActualizarPassword.Token);
            response = ServicioEnviarCorreo.Enviar(Correo, data);
            return response;
        }
    }
}
