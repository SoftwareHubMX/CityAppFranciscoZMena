using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys
{
    public class PredioQuerys
    {
        private PredioInsert PredioInsert;
        private IdPredioSelect IdPredioSelect;
        private PredioSelect PredioSelect;
        private PrediosSelect PrediosSelect;
        private PredioUpdate PredioUpdate;

        public PredioQuerys(CityAppContext cityAppContext)
        {
            PredioInsert = new PredioInsert(cityAppContext);
            IdPredioSelect = new IdPredioSelect(cityAppContext);
            PredioSelect = new PredioSelect(cityAppContext);
            PrediosSelect = new PrediosSelect(cityAppContext);
            PredioUpdate = new PredioUpdate(cityAppContext);
        }

        //insert
        public Response<object> InsertPredio(Predio predio)
        {
            return PredioInsert.InsertPredio(predio);
        }

        //select
        public Response<int> SelectIdPredioClaves(string clave, string claveCatastral)
        {
            return IdPredioSelect.SelectIdPredioClaves(clave, claveCatastral);
        }
        public Response<Predio> SelectPredioConsultaPredioUsuario(ConsultaPredioUsuario consultaPredioUsuario)
        {
            return PredioSelect.SelectPredioConsultaPredioUsuario(consultaPredioUsuario);
        }
        public Response<Predio> SelectPredioIdPredio(int idPredio)
        {
            return PredioSelect.SelectPredioIdPredio(idPredio);
        }
        public Response<IEnumerable<Predio>> SelectPrediosFiltros(FiltroPredios filtroPredios)
        {
            return PrediosSelect.SelectPrediosFiltros(filtroPredios);
        }
        //Update
        public Response<object> UpdatePredio(Predio predio)
        {
            return PredioUpdate.UpdatePredio(predio);
        }
    }
}
