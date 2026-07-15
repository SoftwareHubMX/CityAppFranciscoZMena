using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenLoginQuerys
{
    public class TokenLoginQuerys
    {
        private TokenLoginInsert TokenLoginInsert;
        private TokensLoginSelect TokensLoginSelect;
        private TokenLoginSelect TokenLoginSelect;
        private TokensLoginDelete TokensLoginDelete;
        private TokenLoginDelete TokenLoginDelete;

        public TokenLoginQuerys(CityAppContext cityAppContext)
        {
            TokenLoginInsert = new TokenLoginInsert(cityAppContext);
            TokensLoginSelect = new TokensLoginSelect(cityAppContext);
            TokenLoginSelect = new TokenLoginSelect(cityAppContext);
            TokensLoginDelete = new TokensLoginDelete(cityAppContext);
            TokenLoginDelete = new TokenLoginDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertTokenLogin(TokenLogin tokenLogin)
        {
            return TokenLoginInsert.InsertTokenLogin(tokenLogin);
        }

        //select
        public Response<IEnumerable<TokenLogin>> SelectTokensLoginMantenerSesionIdCuenta(bool mantenerSesion, int idCuenta)
        {
            return TokensLoginSelect.SelectTokensLoginMantenerSesionIdCuenta(mantenerSesion, idCuenta);
        }
        public Response<TokenLogin> SelectTokenLoginToken(string token)
        {
            return TokenLoginSelect.SelectTokenLoginToken(token);
        }
        public Response<IEnumerable<TokenLogin>> SelectTokensLoginIdCuenta(int idCuenta)
        {
            return TokensLoginSelect.SelectTokensLoginIdCuenta(idCuenta);
        }

        //delete
        public Response<object> DeleteTokensLogin(IEnumerable<TokenLogin> tokensLogin)
        {
            return TokensLoginDelete.DeleteTokensLogin(tokensLogin);
        }
        public Response<object> DeleteTokenLogin(TokenLogin tokenLogin)
        {
            return TokenLoginDelete.DeleteTokenLogin(tokenLogin);
        }
    }
}
