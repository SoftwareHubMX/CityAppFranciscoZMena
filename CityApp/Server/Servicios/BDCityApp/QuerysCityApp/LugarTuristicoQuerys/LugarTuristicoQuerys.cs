using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys
{
    public class LugarTuristicoQuerys
    {
        private LugarTuristicoInsert LugarTuristicoInsert;
        private IdLugarTuristicoSelect IdLugarTuristicoSelect;
        private LugaresTuristicosSelect LugaresTuristicosSelect;
        private LugarTuristicoUpdate LugarTuristicoUpdate;
        private LugarTuristicoDelete LugarTuristicoDelete;
        private LugarTuristicoSelect LugarTuristicoSelect;

        public LugarTuristicoQuerys(CityAppContext cityAppContext)
        {
            LugarTuristicoInsert = new LugarTuristicoInsert(cityAppContext);
            IdLugarTuristicoSelect = new IdLugarTuristicoSelect(cityAppContext);
            LugaresTuristicosSelect = new LugaresTuristicosSelect(cityAppContext);
            LugarTuristicoSelect = new LugarTuristicoSelect(cityAppContext);
            LugarTuristicoUpdate = new LugarTuristicoUpdate(cityAppContext);
            LugarTuristicoDelete = new LugarTuristicoDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertLugarTuristico(LugarTuristico lugarTuristico)
        {
            return LugarTuristicoInsert.InsertLugarTuristico(lugarTuristico);
        }

        //select
        public Response<LugarTuristico> SelectLugarTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            return LugarTuristicoSelect.SelectLugarTuristicoIdLugarTuristico(idLugarTuristico);
        }
        public Response<int> SelectIdLugarTuristicoNombre(string nombre)
        {
            return IdLugarTuristicoSelect.SelectIdLugarTuristicoNombre(nombre);
        }
        public Response<IEnumerable<LugarTuristico>> SelectLugaresTuristicosFiltros(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            return LugaresTuristicosSelect.SelectLugaresTuristicosFiltros(filtroLugaresTuristicos);
        }

        public Response<LugarTuristico> SelectLugarTuristicoCompletoIdLugarTuristico(int idLugarTuristico)
        {
            return LugarTuristicoSelect.SelectLugarTuristicoCompletoIdLugarTuristico(idLugarTuristico);
        }
        public Response<IEnumerable<LugarTuristico>> SelectLugarTuristicoTiposLugarTuristico(int idTipoLugarTuristico, FechasDashBoard fechasDashBoard)
        {
            return LugaresTuristicosSelect.SelectLugarTuristicoTiposLugarTuristico(idTipoLugarTuristico, fechasDashBoard);
        }
        public Response<IEnumerable<LugarTuristico>> SelectLugaresTuristicosAppAleatorio(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            return LugaresTuristicosSelect.SelectLugaresTuristicosAppAleatorio(filtroLugaresTuristicos);
        }

        public Response<object> UpdateLugarTuristico(LugarTuristico lugarTuristico)
        {
            return LugarTuristicoUpdate.UpdateLugarTuristico(lugarTuristico);
        }

        public Response<object> DeleteLugarTuristico(LugarTuristico LugarTuristico)
        {
            return LugarTuristicoDelete.DeleteLugarTuristico(LugarTuristico);
        }
    }
}
