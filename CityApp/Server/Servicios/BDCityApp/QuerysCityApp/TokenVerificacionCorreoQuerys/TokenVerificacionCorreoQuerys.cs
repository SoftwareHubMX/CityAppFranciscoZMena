using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys
{
    public class TokenVerificacionCorreoQuerys
    {
        private TokenSelect TokenSelect;
        private TokenVerificacionCorreoSelect TokenVerificacionCorreoSelect;
        private TokenVerificacionCorreoUpdate TokenVerificacionCorreoUpdate;

        public TokenVerificacionCorreoQuerys(CityAppContext cityAppContext)
        {
            TokenSelect = new TokenSelect(cityAppContext);
            TokenVerificacionCorreoSelect = new TokenVerificacionCorreoSelect(cityAppContext);
            TokenVerificacionCorreoUpdate = new TokenVerificacionCorreoUpdate(cityAppContext);
        }

        //select
        public Response<string> SelectTokenToken(string token)
        {
            return TokenSelect.SelectTokenToken(token);
        }
        public Response<TokenVerificacionCorreo> SelectTokenVerificacionCorreo(string token)
        {
            return TokenVerificacionCorreoSelect.SelectTokenVerificacionCorreo(token);
        }
        public Response<object> UpdateTokenVerificacionCorreo(TokenVerificacionCorreo tokenVerificacionCorreo)
        {
            return TokenVerificacionCorreoUpdate.UpdateTokenVerificacionCorreo(tokenVerificacionCorreo);
        }
    }
}
