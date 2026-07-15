using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys.Update
{
    public class TokenContadorAccesosUpdate
    {
        private UpdateCityApp<TokenContadorAccesos> UpdateCityApp;

        public TokenContadorAccesosUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<TokenContadorAccesos>(cityAppContext);
        }

        public Response<object> UpdateTokenContadorAccesos(TokenContadorAccesos tokenContadorAccesos)
        {
            return UpdateCityApp.Save(tokenContadorAccesos);
        }
    }
}
