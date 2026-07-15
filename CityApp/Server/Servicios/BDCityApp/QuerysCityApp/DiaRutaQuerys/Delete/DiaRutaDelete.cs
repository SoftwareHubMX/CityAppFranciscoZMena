using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Delete
{
    public class DiaRutaDelete
    {
        private DeleteCityApp<DiaRuta> DeleteCityApp;

        public DiaRutaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<DiaRuta>(cityAppContext);
        }

        public Response<object> DeleteDiaRuta(DiaRuta diaRuta)
        {
            return DeleteCityApp.Save(diaRuta);
        }
    }
}
