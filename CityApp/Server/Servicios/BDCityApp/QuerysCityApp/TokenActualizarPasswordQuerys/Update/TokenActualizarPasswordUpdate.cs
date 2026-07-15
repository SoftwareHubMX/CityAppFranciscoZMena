using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Update
{
    public class TokenActualizarPasswordUpdate
    {
        private UpdateCityApp<TokenActualizarPassword> UpdateCityApp;

        public TokenActualizarPasswordUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<TokenActualizarPassword>(cityAppContext);
        }

        public Response<object> UpdateTokenActualizarPassword(TokenActualizarPassword tokenActualizarPassword)
        {
            return UpdateCityApp.Save(tokenActualizarPassword);
        }
    }
}
