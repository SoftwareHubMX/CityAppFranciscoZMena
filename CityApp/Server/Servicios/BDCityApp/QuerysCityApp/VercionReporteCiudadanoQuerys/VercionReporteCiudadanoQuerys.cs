using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys
{
    public class VercionReporteCiudadanoQuerys
    {
        private VercionReporteCiudadanoInsert VercionReporteCiudadanoInsert;
        private IdVercionReporteCiudadanoSelect IdVercionReporteCiudadanoSelect;
        private VercionesReporteCiudadanoSelect VercionesReporteCiudadanoSelect;

        public VercionReporteCiudadanoQuerys(CityAppContext cityAppContext)
        {
            VercionReporteCiudadanoInsert = new VercionReporteCiudadanoInsert(cityAppContext);
            IdVercionReporteCiudadanoSelect = new IdVercionReporteCiudadanoSelect(cityAppContext);
            VercionesReporteCiudadanoSelect = new VercionesReporteCiudadanoSelect(cityAppContext);
        }

        //insert
        public Response<object> InsertVercionReporteCiudadano(VercionReporteCiudadano vercionReporteCiudadano)
        {
            return VercionReporteCiudadanoInsert.InsertVercionReporteCiudadano(vercionReporteCiudadano);
        }

        //select
        public Response<int> SelectUltimoIdVercionReporteCiudadanoIdCuentaDescripcion(int idCuenta, string descripcion)
        {
            return IdVercionReporteCiudadanoSelect.SelectUltimoIdVercionReporteCiudadanoIdCuentaDescripcion(idCuenta, descripcion);
        }
        public Response<IEnumerable<VercionReporteCiudadano>> SelectVercionesReporteCiudadanoIdCuentaIdReporteCiudadano(int idCuenta, int idReporteCiudadano)
        {
            return VercionesReporteCiudadanoSelect.SelectVercionesReporteCiudadanoIdCuentaIdReporteCiudadano(idCuenta, idReporteCiudadano);
        }
        public Response<IEnumerable<VercionReporteCiudadano>> SelectVercionesReporteCiudadanoIdReporteCiudadano(int idReporteCiudadano)
        {
            return VercionesReporteCiudadanoSelect.SelectVercionesReporteCiudadanoIdReporteCiudadano(idReporteCiudadano);
        }
    }
}
