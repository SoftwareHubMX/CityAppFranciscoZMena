using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select
{
    public class IdsCuentaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdsCuentaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<int>> SelectIdsCuentaIdRol(int idRol)
        {
            Response<IEnumerable<int>> response = new Response<IEnumerable<int>>();

            response.Data = from data in CityAppContext.Cuentas
                            where data.IdRol == idRol
                            select data.IdCuenta;

            response.Status = SelectCityApp.ValidarLista(response.Data);

            return response;
        }

        public Response<IEnumerable<int>> SelectIdsCuentaIdReporteCiudadano(int idReporteCiudadano)
        {
            Response<IEnumerable<int>> response = new Response<IEnumerable<int>>();

            response.Data = from data in CityAppContext.VercionesReporteCiudadano
                            where data.IdReporteCiudadano == idReporteCiudadano
                            select data.IdCuenta;

            response.Status = SelectCityApp.ValidarLista(response.Data);

            return response;
        }
    }
}
