using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys.Select
{
    public class VercionesReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<VercionReporteCiudadano> SelectCityApp = new SelectCityApp<VercionReporteCiudadano>();

        public VercionesReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<VercionReporteCiudadano>> SelectVercionesReporteCiudadanoIdCuentaIdReporteCiudadano(int idCuenta, int idReporteCiudadano)
        {
            Response<IEnumerable<VercionReporteCiudadano>> response = new Response<IEnumerable<VercionReporteCiudadano>>();

            try
            {
                response.Data = from data in CityAppContext.VercionesReporteCiudadano
                                 where data.IdCuenta == idCuenta
                                 && data.IdReporteCiudadano == idReporteCiudadano
                                 orderby data.IdVercionReporteCiudadano
                                 select new VercionReporteCiudadano()
                                 {
                                     IdVercionReporteCiudadano = data.IdVercionReporteCiudadano,
                                     Descripcion = data.Descripcion,
                                     FechaReporte = data.FechaReporte,
                                     IdCuenta = data.IdCuenta,
                                     DireccionReporteCiudadano = data.DireccionReporteCiudadano
                                 };

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<VercionReporteCiudadano>> SelectVercionesReporteCiudadanoIdReporteCiudadano(int idReporteCiudadano)
        {
            Response<IEnumerable<VercionReporteCiudadano>> response = new Response<IEnumerable<VercionReporteCiudadano>>();

            try
            {
                response.Data = from data in CityAppContext.VercionesReporteCiudadano
                                where data.IdReporteCiudadano == idReporteCiudadano
                                select new VercionReporteCiudadano()
                                {
                                    IdVercionReporteCiudadano = data.IdVercionReporteCiudadano,
                                    Descripcion = data.Descripcion,
                                    FechaReporte = data.FechaReporte,
                                    IdCuenta = data.IdCuenta,
                                    DireccionReporteCiudadano = data.DireccionReporteCiudadano
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
