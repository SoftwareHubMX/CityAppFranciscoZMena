using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys.Insert
{
    public class TokenContadorAccesosInsert
    {
        private InsertCityApp<TokenContadorAccesos> InsertCityApp;

        public TokenContadorAccesosInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<TokenContadorAccesos>(cityAppContext);
        }

        public Response<object> InsertTokenContadorAccesos(TokenContadorAccesos tokenContadorAccesos)
        {
            return InsertCityApp.Save(tokenContadorAccesos);
        }
    }
}
