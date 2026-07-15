using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys;
using CityApp.Server.Servicios.Correo;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers.Correos;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContadorAccesoLogic
{
    public class ResetearContadorLogic
    {
        private TokenContadorAccesosQuerys TokenContadorAccesosQuerys;
        private ContadorAccesoQuerys ContadorAccesoQuerys;
        private ContactoQuerys ContactoQuerys;

        private ServicioEnviarCorreo ServicioEnviarCorreo = new ServicioEnviarCorreo();

        private string Token;
        private TokenContadorAccesos TokenContadorAccesos;

        public ResetearContadorLogic(CityAppContext cityAppContext, string token)
        {
            TokenContadorAccesosQuerys = new TokenContadorAccesosQuerys(cityAppContext);
            ContadorAccesoQuerys = new ContadorAccesoQuerys(cityAppContext);
            ContactoQuerys = new ContactoQuerys(cityAppContext);

            Token = token;
        }

        public Response<object> Resetear()
        {
            Response<object> response = new Response<object>();

            Response<TokenContadorAccesos> responseTokenContadorAccesos = TokenContadorAccesosQuerys.SelectTokenContadorAccesosToken(Token);
            response.Status = responseTokenContadorAccesos.Status;
            if (response.Status.Exito == 1)
            {
                TokenContadorAccesos = responseTokenContadorAccesos.Data;
                response = ActualizarContador();
                if (response.Status.Exito == 1)
                {
                    response = EnviarMail();
                }
            }

            return response;
        }

        private Response<object> ActualizarContador()
        {
            Response<object> response = new Response<object>();

            Response<ContadorAcceso> responseContadorAcceso = ContadorAccesoQuerys.SelectContadorAccesoIdCuenta(TokenContadorAccesos.IdCuenta);
            response.Status = responseContadorAcceso.Status;
            if (response.Status.Exito == 1)
            {
                responseContadorAcceso.Data.Intento = 0;
                response = ContadorAccesoQuerys.UpdateContadorAcceso(responseContadorAcceso.Data);
                if (response.Status.Exito == 1)
                {
                    TokenContadorAccesos.Token = "NA";
                    response = TokenContadorAccesosQuerys.UpdateTokenContadorAccesos(TokenContadorAccesos);
                }
            }

            return response;
        }

        private Response<object> EnviarMail()
        {
            Response<object> response = new Response<object>();
            Response<string> responseCorreo = ContactoQuerys.SelectCorreoIdCuenta(TokenContadorAccesos.IdCuenta);
            response.Status = responseCorreo.Status;
            if (response.Status.Exito == 1)
            {
                string data = CorreoContadorAccesoReseteado.GetCorreo();
                response = ServicioEnviarCorreo.Enviar(responseCorreo.Data, data);
            }
            return response;
        }
    }
}
