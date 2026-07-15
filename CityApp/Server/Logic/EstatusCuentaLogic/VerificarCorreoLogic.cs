using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EstatusCuentaLogic
{
    public class VerificarCorreoLogic
    {
        private TokenVerificacionCorreoQuerys TokenVerificacionCorreoQuerys;
        private EstatusCuentaQuerys EstatusCuentaQuerys;
        private ContactoQuerys ContactoQuerys;

        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private string Token;
        private TokenVerificacionCorreo TokenVerificacionCorreo;

        public VerificarCorreoLogic(CityAppContext cityAppContext, string token)
        {
            TokenVerificacionCorreoQuerys = new TokenVerificacionCorreoQuerys(cityAppContext);
            EstatusCuentaQuerys = new EstatusCuentaQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);

            Token = token;
        }

        public Response<object> Verificar()
        {
            Response<object> response = new Response<object>();

            Response<TokenVerificacionCorreo> responseTokenVerificacion = TokenVerificacionCorreoQuerys.SelectTokenVerificacionCorreo(Token);
            response.Status = responseTokenVerificacion.Status;
            if (response.Status.Exito == 1)
            {
                Response<EstatusCuenta> responseEstatusCuenta = EstatusCuentaQuerys.SelectEstatusCuentaIdCuenta(responseTokenVerificacion.Data.IdCuenta);
                response.Status = responseEstatusCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    responseEstatusCuenta.Data.CorreoVerificado = true;
                    response = EstatusCuentaQuerys.UpdateEstatusCuenta(responseEstatusCuenta.Data);
                    if (response.Status.Exito == 1)
                    {
                        TokenVerificacionCorreo = responseTokenVerificacion.Data;
                        response = ActualizarTokenVerificacion();
                        if (response.Status.Exito == 1)
                        {
                            response = EnviarMail();
                        }
                    }
                }
            }

            return response;
        }

        private Response<object> ActualizarTokenVerificacion()
        {
            Response<object> response = new Response<object>();
            TokenVerificacionCorreo.Token = "NA";
            response = TokenVerificacionCorreoQuerys.UpdateTokenVerificacionCorreo(TokenVerificacionCorreo);
            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            Response<string> responseCorreo = ContactoQuerys.SelectCorreoIdCuenta(TokenVerificacionCorreo.IdCuenta);
            response.Status = responseCorreo.Status;
            if (response.Status.Exito == 1)
            {
                string data = CorreoCuentaVerificada.GetCorreo();
                response = ServicioEnviarCorreo.Enviar(responseCorreo.Data, data);
            }
            return response;
        }
    }
}
