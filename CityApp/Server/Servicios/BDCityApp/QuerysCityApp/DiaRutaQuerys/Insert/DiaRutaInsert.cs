using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Insert
{
    public class DiaRutaInsert
    {
        private InsertCityApp<DiaRuta> InsertCityApp;

        public DiaRutaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<DiaRuta>(cityAppContext);
        }

        public Response<object> InsertDiaRuta(DiaRuta diaRuta)
        {
            return InsertCityApp.Save(diaRuta);
        }
    }
}
