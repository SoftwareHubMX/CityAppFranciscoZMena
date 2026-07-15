using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Delete
{
    public class TokensLoginDelete
    {
        private DeleteCityApp<TokenLogin> DeleteCityApp;

        public TokensLoginDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<TokenLogin>(cityAppContext);
        }

        public Response<object> DeleteTokensLogin(IEnumerable<TokenLogin> tokensLogin)
        {
            return DeleteCityApp.SaveMultiple(tokensLogin);
        }
    }
}
