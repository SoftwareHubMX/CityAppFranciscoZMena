using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.LugarTuristicoLogic
{
    public class ConsultarLugaresTuristicosAppLogic
    {
        private LugarTuristicoQuerys LugarTuristicoQuerys;
        private FiltroLugaresTuristicos FiltroLugaresTuristicos;
        private List<LugarTuristico> LugarTuristico;

        public ConsultarLugaresTuristicosAppLogic(CityAppContext cityAppContext, FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContext);
            FiltroLugaresTuristicos = filtroLugaresTuristicos;
        }

        public Response<List<LugarTuristico>> Consultar()
        {
            Response<List<LugarTuristico>> response = new Response<List<LugarTuristico>>();

            Response<IEnumerable<LugarTuristico>> responseLugarTuristico = LugarTuristicoQuerys.SelectLugaresTuristicosAppAleatorio(FiltroLugaresTuristicos);
            response.Status = responseLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<LugarTuristico>();
                response.Data = responseLugarTuristico.Data.ToList();
            }

            return response;
        }
    }
}
