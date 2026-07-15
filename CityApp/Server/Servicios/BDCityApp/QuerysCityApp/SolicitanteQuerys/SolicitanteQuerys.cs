using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys
{
    public class SolicitanteQuerys
    {
        private SolicitanteInsert SolicitanteInsert;
        private SolicitanteSelect SolicitanteSelect;
        private SolicitantesSelect SolicitantesSelect;
        private SolicitanteUpdate SolicitanteUpdate;
        private SolicitanteDelete SolicitanteDelete;

        public SolicitanteQuerys(CityAppContext cityAppContext)
        {
            SolicitanteInsert = new SolicitanteInsert(cityAppContext);
            SolicitanteSelect = new SolicitanteSelect(cityAppContext);
            SolicitantesSelect = new SolicitantesSelect(cityAppContext);
            SolicitanteUpdate = new SolicitanteUpdate(cityAppContext);
            SolicitanteDelete = new SolicitanteDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertSolicitud(Solicitante solicitante)
        {
            return SolicitanteInsert.InsertSolicitante(solicitante);
        }

        //select
        public Response<Solicitante> SelectSolicitanteIdSolicitante(int idSolicitante)
        {
            return SolicitanteSelect.SelectSolicitanteIdSolicitante(idSolicitante);
        }
        
        public Response<IEnumerable<Solicitante>> SelectSolicitantes()
        {
            return SolicitantesSelect.SelectSolicitantes();
        }
        public Response<Solicitante> SelectLastIdSolicitante()
        {
            return SolicitanteSelect.SelectLastIdSolicitante();
        }

        //update
        public Response<object> UpdateSolicitante(Solicitante solicitante)
        {
            return SolicitanteUpdate.UpdateSolicitante(solicitante);
        }

        //delete
        public Response<object> DeleteSolicitante(Solicitante solicitante)
        {
            return SolicitanteDelete.DeleteSolicitante(solicitante);
        }
    }
}
