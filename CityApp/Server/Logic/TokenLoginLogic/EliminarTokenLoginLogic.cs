using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TokenLoginLogic
{
    public class EliminarTokenLoginLogic
    {
        private TokenLoginQuerys TokenLoginQuerys;

        private string Token;

        public EliminarTokenLoginLogic(CityAppContext cityAppContext, string token)
        {
            TokenLoginQuerys = new TokenLoginQuerys(cityAppContext);

            Token = token;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<TokenLogin> responseTokenLogin = TokenLoginQuerys.SelectTokenLoginToken(Token);
            response.Status = responseTokenLogin.Status;
            if (response.Status.Exito == 1)
            {
                response = TokenLoginQuerys.DeleteTokenLogin(responseTokenLogin.Data);
            }

            return response;
        }
    }
}
