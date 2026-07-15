using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Update
{
    public class DiaRutaUpdate
    {
        private UpdateCityApp<DiaRuta> UpdateCityApp;

        public DiaRutaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<DiaRuta>(cityAppContext);
        }
        public Response<object> UpdateDiaRuta(DiaRuta diaRuta)
        {
            return UpdateCityApp.Save(diaRuta);
        }
    }
}
