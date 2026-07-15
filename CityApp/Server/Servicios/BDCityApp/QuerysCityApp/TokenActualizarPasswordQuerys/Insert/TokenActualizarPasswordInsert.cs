using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TokenActualizarPasswordQuerys.Insert
{
    public class TokenActualizarPasswordInsert
    {
        private InsertCityApp<TokenActualizarPassword> InsertCityApp;

        public TokenActualizarPasswordInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<TokenActualizarPassword>(cityAppContext);
        }

        public Response<object> InsertTokenActualizarPassword(TokenActualizarPassword tokenActualizarPassword)
        {
            return InsertCityApp.Save(tokenActualizarPassword);
        }
    }
}
