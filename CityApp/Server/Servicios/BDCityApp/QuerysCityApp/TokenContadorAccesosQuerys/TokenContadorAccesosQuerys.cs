using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenContadorAccesosQuerys
{
    public class TokenContadorAccesosQuerys
    {
        private TokenContadorAccesosInsert TokenContadorAccesosInsert;
        private TokenSelect TokenSelect;
        private TokenContadorAccesosSelect TokenContadorAccesosSelect;
        private TokenContadorAccesosUpdate TokenContadorAccesosUpdate;

        public TokenContadorAccesosQuerys(CityAppContext cityAppContext)
        {
            TokenContadorAccesosInsert = new TokenContadorAccesosInsert(cityAppContext);
            TokenSelect = new TokenSelect(cityAppContext);
            TokenContadorAccesosSelect = new TokenContadorAccesosSelect(cityAppContext);
            TokenContadorAccesosUpdate = new TokenContadorAccesosUpdate(cityAppContext);
        }

        //insert
        public Response<object> InsertTokenContadorAccesos(TokenContadorAccesos tokenContadorAccesos)
        {
            return TokenContadorAccesosInsert.InsertTokenContadorAccesos(tokenContadorAccesos);
        }

        //select
        public Response<string> SelectTokenToken(string token)
        {
            return TokenSelect.SelectTokenToken(token);
        }
        public Response<TokenContadorAccesos> SelectTokenContadorAccesosIdCuenta(int idCuenta)
        {
            return TokenContadorAccesosSelect.SelectTokenContadorAccesosIdCuenta(idCuenta);
        }
        public Response<TokenContadorAccesos> SelectTokenContadorAccesosToken(string token)
        {
            return TokenContadorAccesosSelect.SelectTokenContadorAccesosToken(token);
        }

        //update
        public Response<object> UpdateTokenContadorAccesos(TokenContadorAccesos tokenContadorAccesos)
        {
            return TokenContadorAccesosUpdate.UpdateTokenContadorAccesos(tokenContadorAccesos);
        }
    }
}
