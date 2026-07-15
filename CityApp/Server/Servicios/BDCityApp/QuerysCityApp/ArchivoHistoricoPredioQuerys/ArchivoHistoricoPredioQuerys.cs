using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys
{
    public class ArchivoHistoricoPredioQuerys
    {
        private ArchivoHistoricoPredioInsert ArchivoHistoricoPredioInsert;
        private ArchivoHistoricoPredioSelect ArchivoHistoricoPredioSelect;
        private ArchivoHistoricoPredioDelete ArchivoHistoricoPredioDelete;
        private ArchivoHistoricosPrediosSelect ArchivoHistoricosPrediosSelect;

        public ArchivoHistoricoPredioQuerys(CityAppContext cityAppContext)
        {
            ArchivoHistoricoPredioInsert = new ArchivoHistoricoPredioInsert(cityAppContext);
            ArchivoHistoricoPredioSelect = new ArchivoHistoricoPredioSelect(cityAppContext);
            ArchivoHistoricoPredioDelete = new ArchivoHistoricoPredioDelete(cityAppContext);
            ArchivoHistoricosPrediosSelect = new ArchivoHistoricosPrediosSelect(cityAppContext);
        }

        //insert
        public Response<object> InsertArchivoHistoricoPredio(ArchivoHistoricoPredio ArchivoHistoricoPredio)
        {
            return ArchivoHistoricoPredioInsert.InsertArchivoHistoricoPredio(ArchivoHistoricoPredio);
        }

        //select
        public Response<ArchivoHistoricoPredio> SelectArchivoHistoricoPredioIdArchivoHistoricoPredio(int idArchivoHistoricoPredio)
        {
            return ArchivoHistoricoPredioSelect.SelectArchivoHistoricoPredioIdArchivoHistoricoPredio(idArchivoHistoricoPredio);
        }
        public Response<ArchivoHistoricoPredio> SelectArchivoHistoricoPredioIdHistoricoPredioPrincipal(int idHistoricoPredio)
        {
            return ArchivoHistoricoPredioSelect.SelectArchivoHistoricoPredioIdHistoricoPredioPrincipal(idHistoricoPredio);
        }
        public Response<ArchivoHistoricoPredio> SelectArchivoHistoricoPredioIdHistoricoPredioFirst(int idHistoricoPredio)
        {
            return ArchivoHistoricoPredioSelect.SelectArchivoHistoricoPredioIdHistoricoPredioFirst(idHistoricoPredio);
        }

        public Response<IEnumerable<ArchivoHistoricoPredio>> SelectArchivosHistoricosPredios()
        {
            return ArchivoHistoricosPrediosSelect.SelectArchivosHistoricosPredios();
        }

        //delete
        public Response<object> DeleteArchivoHistoricoPredio(ArchivoHistoricoPredio ArchivoHistoricoPredio)
        {
            return ArchivoHistoricoPredioDelete.DeleteArchivoHistoricoPredio(ArchivoHistoricoPredio);
        }
    }
}
