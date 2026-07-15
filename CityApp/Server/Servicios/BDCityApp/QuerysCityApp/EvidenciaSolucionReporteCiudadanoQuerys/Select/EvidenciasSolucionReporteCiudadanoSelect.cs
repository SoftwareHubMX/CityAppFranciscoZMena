using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Select
{
    public class EvidenciasSolucionReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EvidenciaSolucionReporteCiudadano> SelectCityApp = new SelectCityApp<EvidenciaSolucionReporteCiudadano>();

        public EvidenciasSolucionReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<EvidenciaSolucionReporteCiudadano>> SelectEvidenciasSolucionReporteCiudadanoIdReporteCiudadano(int idReporteCiudadano)
        {
            Response<IEnumerable<EvidenciaSolucionReporteCiudadano>> response = new Response<IEnumerable<EvidenciaSolucionReporteCiudadano>>();

            try
            {
                response.Data = from data in CityAppContext.EvidenciasSolucionReporteCiudadano
                                where data.IdReporteCiudadano == idReporteCiudadano
                                select new EvidenciaSolucionReporteCiudadano()
                                {
                                    IdEnvidenciaSolucionReporteCiudadano = data.IdEnvidenciaSolucionReporteCiudadano,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Observaciones = data.Observaciones,
                                    IdReporteCiudadano = data.IdReporteCiudadano
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
