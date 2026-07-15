using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys
{
    public class EvidenciaSolucionReporteCiudadanoQuerys
    {
        private EvidenciaSolucionReporteCiudadanoInsert EvidenciaSolucionReporteCiudadanoInsert;
        private EvidenciasSolucionReporteCiudadanoSelect EvidenciasSolucionReporteCiudadanoSelect;
        private EvidenciaSolucionReporteCiudadanoSelect EvidenciaSolucionReporteCiudadanoSelect;
        private EvidenciaSolucionReporteCiudadanoDelete EvidenciaSolucionReporteCiudadanoDelete;

        public EvidenciaSolucionReporteCiudadanoQuerys(CityAppContext cityAppContext)
        {
            EvidenciaSolucionReporteCiudadanoInsert = new EvidenciaSolucionReporteCiudadanoInsert(cityAppContext);
            EvidenciaSolucionReporteCiudadanoSelect = new EvidenciaSolucionReporteCiudadanoSelect(cityAppContext);
            EvidenciasSolucionReporteCiudadanoSelect = new EvidenciasSolucionReporteCiudadanoSelect(cityAppContext);
            EvidenciaSolucionReporteCiudadanoDelete = new EvidenciaSolucionReporteCiudadanoDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertEvidenciaReporteCiudadano(EvidenciaSolucionReporteCiudadano evidenciaSolucionReporteCiudadano)
        {
            return EvidenciaSolucionReporteCiudadanoInsert.InsertEvidenciaReporteCiudadano(evidenciaSolucionReporteCiudadano);
        }

        //select
        public Response<EvidenciaSolucionReporteCiudadano> SelectEvidenciaSolucionReporteCiudadanoIdEvidenciaSolucionReporteCiudadano(int idEnvidenciaSolucionReporteCiudadano)
        {
            return EvidenciaSolucionReporteCiudadanoSelect.SelectEvidenciaSolucionReporteCiudadanoIdEvidenciaSolucionReporteCiudadano(idEnvidenciaSolucionReporteCiudadano);
        }
        public Response<IEnumerable<EvidenciaSolucionReporteCiudadano>> SelectEvidenciasSolucionReporteCiudadanoIdReporteCiudadano(int idReporteCiudadano)
        {
            return EvidenciasSolucionReporteCiudadanoSelect.SelectEvidenciasSolucionReporteCiudadanoIdReporteCiudadano(idReporteCiudadano);
        }

        //delete
        public Response<object> DeleteEvidenciaReporteCiudadano(EvidenciaSolucionReporteCiudadano evidenciaSolucionReporteCiudadano)
        {
            return EvidenciaSolucionReporteCiudadanoDelete.DeleteEvidenciaReporteCiudadano(evidenciaSolucionReporteCiudadano);
        }
    }
}
