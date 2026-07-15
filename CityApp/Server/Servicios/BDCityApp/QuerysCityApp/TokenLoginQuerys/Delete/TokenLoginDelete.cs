using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Delete
{
    public class TokenLoginDelete
    {
        private DeleteCityApp<TokenLogin> DeleteCityApp;

        public TokenLoginDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<TokenLogin>(cityAppContext);
        }

        public Response<object> DeleteTokenLogin(TokenLogin tokenLogin)
        {
            return DeleteCityApp.Save(tokenLogin);
        }
    }
}
