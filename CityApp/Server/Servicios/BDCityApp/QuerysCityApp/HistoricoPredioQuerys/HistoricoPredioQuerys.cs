using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys
{
    public class HistoricoPredioQuerys
    {
        private HistoricoPredioInsert HistoricoPredioInsert;
        private HistoricoPredioSelect HistoricoPredioSelect;
        private HistoricosPrediosSelect HistoricosPrediosSelect;
        private IdHistoricoPredioSelect IdHistoricoPredioSelect;
        private HistoricoPredioUpdate HistoricoPredioUpdate;
        private HistoricoPredioDelete HistoricoPredioDelete;

        public HistoricoPredioQuerys(CityAppContext cityAppContext)
        {
            HistoricoPredioInsert = new HistoricoPredioInsert(cityAppContext);
            HistoricoPredioSelect = new HistoricoPredioSelect(cityAppContext);
            HistoricosPrediosSelect = new HistoricosPrediosSelect(cityAppContext);
            IdHistoricoPredioSelect = new IdHistoricoPredioSelect(cityAppContext);
            HistoricoPredioUpdate = new HistoricoPredioUpdate(cityAppContext);
            HistoricoPredioDelete = new HistoricoPredioDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertHistoricoPredio(HistoricoPredio HistoricoPredio)
        {
            return HistoricoPredioInsert.InsertHistoricoPredio(HistoricoPredio);
        }

        //select
        public Response<HistoricoPredio> SelectHistoricoPredioIdHistoricoPredio(int idHistoricoPredio)
        {
            return HistoricoPredioSelect.SelectHistoricoPredioIdHistoricoPredio(idHistoricoPredio);
        }
        public Response<IEnumerable<HistoricoPredio>> SelectHistoricoPrediosFiltroHistoricoPredios(FiltroHistoricoPredio filtroHistoricoPredios)
        {
            return HistoricosPrediosSelect.SelectHistoricosPrediosFiltroHistoricosPredios(filtroHistoricoPredios);
        }
        public Response<int> SelectUltimoIdHistoricoPredioTexto(string notaActualizacion, DateTime fechaHistorico)
        {
            return IdHistoricoPredioSelect.SelectUltimoIdHistoricoPredioNotaActualizacion(notaActualizacion,fechaHistorico);
        }

        //update
        public Response<object> UpdateHistoricoPredio(HistoricoPredio HistoricoPredio)
        {
            return HistoricoPredioUpdate.UpdateHistoricoPredio(HistoricoPredio);
        }

        //delete
        public Response<object> DeleteHistoricoPredio(HistoricoPredio HistoricoPredio)
        {
            return HistoricoPredioDelete.DeleteHistoricoPredio(HistoricoPredio);
        }
    }
}
