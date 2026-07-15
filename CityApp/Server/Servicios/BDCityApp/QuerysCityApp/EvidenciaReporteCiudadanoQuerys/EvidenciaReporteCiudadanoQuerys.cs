using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys
{
    public class EvidenciaReporteCiudadanoQuerys
    {
        private EvidenciaReporteCiudadanoInsert EvidenciaReporteCiudadanoInsert;
        private EvidenciasReporteCiudadanoSelect EvidenciasReporteCiudadanoSelect;
        private EvidenciaReporteCiudadanoSelect EvidenciaReporteCiudadanoSelect;
        private EvidenciaReporteCiudadanoDelete EvidenciaReporteCiudadanoDelete;

        public EvidenciaReporteCiudadanoQuerys(CityAppContext cityAppContext)
        {
            EvidenciaReporteCiudadanoInsert = new EvidenciaReporteCiudadanoInsert(cityAppContext);
            EvidenciasReporteCiudadanoSelect = new EvidenciasReporteCiudadanoSelect(cityAppContext);
            EvidenciaReporteCiudadanoSelect = new EvidenciaReporteCiudadanoSelect(cityAppContext);
            EvidenciaReporteCiudadanoDelete = new EvidenciaReporteCiudadanoDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertEvidenciaReporteCiudadano(EvidenciaReporteCiudadano evidenciaReporteCiudadano)
        {
            return EvidenciaReporteCiudadanoInsert.InsertEvidenciaReporteCiudadano(evidenciaReporteCiudadano);
        }

        //select
        public Response<IEnumerable<EvidenciaReporteCiudadano>> SelectEvidenciasReporteCiudadanoIdVercionReporteCiudadano(int idVercionReporteCiudadano)
        {
            return EvidenciasReporteCiudadanoSelect.SelectEvidenciasReporteCiudadanoIdVercionReporteCiudadano(idVercionReporteCiudadano);
        }
        public Response<EvidenciaReporteCiudadano> SelectEvidenciaReporteCiudadanoIdEnvidenciaReporteCiudadano(int idEnvidenciaReporteCiudadano)
        {
            return EvidenciaReporteCiudadanoSelect.SelectEvidenciaReporteCiudadanoIdEnvidenciaReporteCiudadano(idEnvidenciaReporteCiudadano);
        }

        //delete
        public Response<object> DeleteEvidenciaReporteCiudadano(EvidenciaReporteCiudadano evidenciaReporteCiudadano)
        {
            return EvidenciaReporteCiudadanoDelete.DeleteEvidenciaReporteCiudadano(evidenciaReporteCiudadano);
        }
    }
}
