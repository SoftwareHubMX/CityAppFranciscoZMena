using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class ActualizarPasswordLogic
    {
        private CuentaQuerys CuentaQuerys;
        private ContactoQuerys ContactoQuerys;
        private TokenLoginQuerys TokenLoginQuerys;

        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private ActualizarPassword ActualizarPassword;
        private int IdCuenta;

        public ActualizarPasswordLogic(CityAppContext cityAppContext, ActualizarPassword actualizarPassword, int idCuenta)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);
            TokenLoginQuerys = new TokenLoginQuerys(cityAppContext);

            ActualizarPassword = actualizarPassword;
            IdCuenta = idCuenta;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<Cuenta> responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(IdCuenta);
            response.Status = responseCuenta.Status;
            if (response.Status.Exito == 1)
            {
                responseCuenta.Data.Password = ActualizarPassword.Password;
                response = CuentaQuerys.UpdateCuenta(responseCuenta.Data);
                if (response.Status.Exito == 1)
                {
                    response = EnviarMail();
                    if (response.Status.Exito == 1)
                    {
                        response = CerrarSesiones();
                    }
                }
            }

            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            Response<string> responseCorreo = ContactoQuerys.SelectCorreoIdCuenta(IdCuenta);
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

            Response<IEnumerable<TokenLogin>> responseTokensLogin = TokenLoginQuerys.SelectTokensLoginIdCuenta(IdCuenta);
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
