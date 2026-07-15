using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Select
{
    public class EvidenciasReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EvidenciaReporteCiudadano> SelectCityApp = new SelectCityApp<EvidenciaReporteCiudadano>();

        public EvidenciasReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<EvidenciaReporteCiudadano>> SelectEvidenciasReporteCiudadanoIdVercionReporteCiudadano(int idVercionReporteCiudadano)
        {
            Response<IEnumerable<EvidenciaReporteCiudadano>> response = new Response<IEnumerable<EvidenciaReporteCiudadano>>();

            try
            {
                response.Data = from data in CityAppContext.EvidenciasReporteCiudadano
                                where data.IdVercionReporteCiudadano == idVercionReporteCiudadano
                                select new EvidenciaReporteCiudadano()
                                {
                                    IdEnvidenciaReporteCiudadano = data.IdEnvidenciaReporteCiudadano,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    IdVercionReporteCiudadano = data.IdVercionReporteCiudadano
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
