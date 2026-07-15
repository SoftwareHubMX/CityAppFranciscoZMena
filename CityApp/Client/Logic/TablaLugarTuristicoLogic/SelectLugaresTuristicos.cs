using CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaLugarTuristicoLogic
{
    public class SelectLugaresTuristicos
    {
        private LugarTuristicoPeticiones LugarTuristicoPeticiones;

        public SelectLugaresTuristicos(HttpClient cliente)
        {
            LugarTuristicoPeticiones = new LugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<List<LugarTuristico>>> SelectAll(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            Response<List<LugarTuristico>> response = await LugarTuristicoPeticiones.consultarLugaresTuristicosFiltos(filtroLugaresTuristicos);
            return response;
        }
    }
}
