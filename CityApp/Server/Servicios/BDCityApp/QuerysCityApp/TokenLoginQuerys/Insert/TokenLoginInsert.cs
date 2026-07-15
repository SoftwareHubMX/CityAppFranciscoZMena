using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Insert
{
    public class TokenLoginInsert
    {
        private InsertCityApp<TokenLogin> InsertCityApp;

        public TokenLoginInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<TokenLogin>(cityAppContext);
        }

        public Response<object> InsertTokenLogin(TokenLogin tokenLogin)
        {
            return InsertCityApp.Save(tokenLogin);
        }
    }
}
