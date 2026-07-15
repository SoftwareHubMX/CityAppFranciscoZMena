using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.LugarTuristicoLogic
{
    public class EditarLugarTuristicoLogic
    {
        private LugarTuristicoQuerys LugarTuristicoQuerys;

        private LugarTuristico lugarTuristico;

        public EditarLugarTuristicoLogic(CityAppContext cityAppContext, LugarTuristico LugarTuristico)
        {
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContext);

            lugarTuristico = LugarTuristico;
        }

        public Response<object> Editar()
        {
            Response<object> response = new Response<object>();

            response = LugarTuristicoQuerys.UpdateLugarTuristico(lugarTuristico);

            return response;
        }
    }
}
