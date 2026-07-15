using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CordeenadaRutaQuerys.Update
{
    public class CordeenadaRutaUpdate
    {
        private UpdateCityApp<CordeenadaRuta> UpdateCityApp;

        public CordeenadaRutaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<CordeenadaRuta>(cityAppContext);
        }
        public Response<object> UpdateCordeenadaRuta(CordeenadaRuta cordeenadaRuta)
        {
            return UpdateCityApp.Save(cordeenadaRuta);
        }
    }
}
