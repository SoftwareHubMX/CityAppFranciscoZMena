using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DiaRutaLogic
{
    public class ActualizarDiaRutaLogic
    {
        private DiaRutaQuerys DiaRutaQuerys;
        private DiaRuta DiaRuta;
        public ActualizarDiaRutaLogic(CityAppContext cityAppContext, DiaRuta diaRuta)
        {
            DiaRutaQuerys = new DiaRutaQuerys(cityAppContext);

            DiaRuta = diaRuta;
        }

        public Response<object> Actualizar()
        {
            return DiaRutaQuerys.UpdateDiaRuta(DiaRuta);
        }
    }
}
