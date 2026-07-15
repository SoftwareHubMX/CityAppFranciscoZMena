using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenVerificacionCorreoQuerys.Update
{
    public class TokenVerificacionCorreoUpdate
    {
        private UpdateCityApp<TokenVerificacionCorreo> UpdateCityApp;

        public TokenVerificacionCorreoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<TokenVerificacionCorreo>(cityAppContext);
        }

        public Response<object> UpdateTokenVerificacionCorreo(TokenVerificacionCorreo tokenVerificacionCorreo)
        {
            return UpdateCityApp.Save(tokenVerificacionCorreo);
        }
    }
}
