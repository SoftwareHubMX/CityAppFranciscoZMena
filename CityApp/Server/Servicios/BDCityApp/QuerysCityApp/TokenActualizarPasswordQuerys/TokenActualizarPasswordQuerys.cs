using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys
{
    public class TokenActualizarPasswordQuerys
    {
        private TokenActualizarPasswordInsert TokenActualizarPasswordInsert;
        private TokenActualizarPasswordSelect TokenActualizarPasswordSelect;
        private TokenSelect TokenSelect;
        private TokenActualizarPasswordUpdate TokenActualizarPasswordUpdate;

        public TokenActualizarPasswordQuerys(CityAppContext cityAppContext)
        {
            TokenActualizarPasswordSelect = new TokenActualizarPasswordSelect(cityAppContext);
            TokenActualizarPasswordInsert = new TokenActualizarPasswordInsert(cityAppContext);
            TokenSelect = new TokenSelect(cityAppContext);
            TokenActualizarPasswordUpdate = new TokenActualizarPasswordUpdate(cityAppContext);
        }

        //insert
        public Response<object> InsertTokenActualizarPassword(TokenActualizarPassword tokenActualizarPassword)
        {
            return TokenActualizarPasswordInsert.InsertTokenActualizarPassword(tokenActualizarPassword);
        }

        //select
        public Response<TokenActualizarPassword> SelectTokenActualizarPasswordToken(string token)
        {
            return TokenActualizarPasswordSelect.SelectTokenActualizarPasswordToken(token);
        }
        public Response<TokenActualizarPassword> SelectTokenActualizarPasswordIdCuenta(int idCuenta)
        {
            return TokenActualizarPasswordSelect.SelectTokenActualizarPasswordIdCuenta(idCuenta);
        }
        public Response<string> SelectTokenToken(string token)
        {
            return TokenSelect.SelectTokenToken(token);
        }

        //update
        public Response<object> UpdateTokenActualizarPassword(TokenActualizarPassword tokenActualizarPassword)
        {
            return TokenActualizarPasswordUpdate.UpdateTokenActualizarPassword(tokenActualizarPassword);
        }
    }
}
