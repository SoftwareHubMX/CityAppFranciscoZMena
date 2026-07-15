using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.LugarTuristicoLogic
{
    public class ConsultarLugaresTuristicosFiltosLogic
    {
        private LugarTuristicoQuerys LugarTuristicoQuerys;

        private FiltroLugaresTuristicos FiltroLugaresTuristicos;

        public ConsultarLugaresTuristicosFiltosLogic(CityAppContext cityAppContext, FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContext);

            FiltroLugaresTuristicos = filtroLugaresTuristicos;
        }

        public Response<List<LugarTuristico>> Consultar()
        {
            Response<List<LugarTuristico>> response = new Response<List<LugarTuristico>>();

            Response<IEnumerable<LugarTuristico>> responseLugarTuristico = LugarTuristicoQuerys.SelectLugaresTuristicosFiltros(FiltroLugaresTuristicos);
            response.Status = responseLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseLugarTuristico.Data.ToList();
                response.Info = responseLugarTuristico.Info;
            }

            return response;
        }
    }
}
