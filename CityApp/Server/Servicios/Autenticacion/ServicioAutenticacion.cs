using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Autenticacion
{
    public class ServicioAutenticacion
    {
        private Codificador Codificador = new Codificador();
        private Random Random = new Random();
        private TokenLoginQuerys TokenLoginQuerys;

        public ServicioAutenticacion(CityAppContext cityAppContext)
        {
            TokenLoginQuerys = new TokenLoginQuerys(cityAppContext);
        }

        public Response<string> GenerarToken(LoginData loginData)
        {
            Response<string> response = new Response<string>();

            try
            {
                Response<TokenLogin> responseTokenLogin = new Response<TokenLogin>();
                string token = "";
                do
                {
                    GeneradorTokens generadorTokens = GeneradorTokens.Instancia();
                    token = generadorTokens.GetToken(30);
                    token = token + Codificador.Encrypt(loginData.Password).Substring(0, 5);
                    token = token + DateTime.Now.ToString("mmff_ss");
                    token = token + generadorTokens.GetToken(Random.Next(2, 18));
                    responseTokenLogin = TokenLoginQuerys.SelectTokenLoginToken(token);
                } while (responseTokenLogin.Status.Exito == 1);

                response.Status = responseTokenLogin.Status;

                if (response.Status.Exito == 2)
                {
                    response.Data = token;
                    response.Status.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al generar el token";
            }

            return response;
        }
    }
}
