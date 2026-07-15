using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class RecuperarPasswordLogic
    {
        private CuentaQuerys CuentaQuerys;
        private TokenActualizarPasswordQuerys TokenActualizarPasswordQuerys;
        private ContactoQuerys ContactoQuerys;
        private TokenLoginQuerys TokenLoginQuerys;

        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private RecuperacionPassword RecuperacionPassword = new RecuperacionPassword();
        private Cuenta Cuenta = new Cuenta();

        public RecuperarPasswordLogic(CityAppContext cityAppContext, RecuperacionPassword recuperacionPassword)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            TokenActualizarPasswordQuerys = new TokenActualizarPasswordQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);
            TokenLoginQuerys = new TokenLoginQuerys(cityAppContext);

            RecuperacionPassword = recuperacionPassword;
        }

        public Response<object> Recuperar()
        {
            Response<object> response = new Response<object>();

            Response<TokenActualizarPassword> responseTokenActualizarPassword = TokenActualizarPasswordQuerys.SelectTokenActualizarPasswordToken(RecuperacionPassword.Token);
            response.Status = responseTokenActualizarPassword.Status;
            if (response.Status.Exito == 1)
            {
                Response<Cuenta> responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(responseTokenActualizarPassword.Data.IdCuenta);
                response.Status = responseCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    Cuenta = responseCuenta.Data;
                    response = ActualizarPassword();
                    if (response.Status.Exito == 1)
                    {
                        response = EnviarMail();
                        if (response.Status.Exito == 1)
                        {
                            if (RecuperacionPassword.CerrarSesiones)
                            {
                                response = CerrarSesiones();
                            }
                        }
                    }
                }
            }

            return response;
        }

        private Response<object> ActualizarPassword()
        {
            Response<object> response = new Response<object>();

            Cuenta.Password = RecuperacionPassword.Password;
            response = CuentaQuerys.UpdateCuenta(Cuenta);

            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            Response<string> responseCorreo = ContactoQuerys.SelectCorreoIdCuenta(Cuenta.IdCuenta);
            response.Status = responseCorreo.Status;
            if (response.Status.Exito == 1)
            {
                string data = CorreoPasswordActualizada.GetCorreo();
                response = ServicioEnviarCorreo.Enviar(responseCorreo.Data, data);
            }
            return response;
        }

        private Response<object> CerrarSesiones()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<TokenLogin>> responseTokensLogin = TokenLoginQuerys.SelectTokensLoginIdCuenta(Cuenta.IdCuenta);
            response.Status = responseTokensLogin.Status;
            if (response.Status.Exito == 1)
            {
                if (responseTokensLogin.Data.Count() > 0)
                {
                    response = TokenLoginQuerys.DeleteTokensLogin(responseTokensLogin.Data);
                }
            }

            return response;
        }
    }
}
