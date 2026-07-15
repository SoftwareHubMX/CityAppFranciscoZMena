using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys.Select
{
    public class IdVercionReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdVercionReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectUltimoIdVercionReporteCiudadanoIdCuentaDescripcion(int idCuenta, string descripcion)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.VercionesReporteCiudadano
                                 orderby data.FechaReporte
                                 where data.IdCuenta == idCuenta
                                 && data.Descripcion == descripcion
                                 select data.IdVercionReporteCiudadano).Last();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
