using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DiaRutaLogic
{
    public class EliminarDiaRutaLogic
    {
        private DiaRutaQuerys DiaRutaQuerys;
        private DiaRuta DiaRuta;

        public EliminarDiaRutaLogic(CityAppContext cityAppContext, DiaRuta diaRuta)
        {
            DiaRutaQuerys = new DiaRutaQuerys(cityAppContext);
            DiaRuta = diaRuta;
        }
        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();
            response = DiaRutaQuerys.DeleteDiaRuta(DiaRuta);
            return response;
        }
    }
}
