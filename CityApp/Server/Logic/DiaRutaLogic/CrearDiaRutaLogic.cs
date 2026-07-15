using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DiaRutaLogic
{
    public class CrearDiaRutaLogic
    {
        private DiaRutaQuerys DiaRutaQuerys;

        private DiaRuta DiaRuta;

        public CrearDiaRutaLogic(CityAppContext cityAppContext, DiaRuta diaRuta)
        {
            DiaRutaQuerys = new DiaRutaQuerys(cityAppContext);

            DiaRuta = diaRuta;
        }

        public Response<object> Crear()
        {
            return DiaRutaQuerys.InsertDiaRuta(DiaRuta);
        }
    }
}
