using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Select
{
    public class TotalBolsasTrabajosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<BolsaTrabajo> SelectCityApp = new SelectCityApp<BolsaTrabajo>();

        public TotalBolsasTrabajosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<BolsaTrabajo>>SelectTotalBolsasTrabajoFechaEstatus(DateTime fechaPublicacion, bool estatus)
        {
            Response<IEnumerable<BolsaTrabajo>> response = new Response<IEnumerable<BolsaTrabajo>>();

            try
            {
                response.Data = CityAppContext.BolsasTrabajos;
                response.Data = response.Data.Where(d => d.FechaPublicacion >= new DateTime(fechaPublicacion.Year, fechaPublicacion.Month, fechaPublicacion.Day, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechaPublicacion.Year, fechaPublicacion.Month, fechaPublicacion.Day, 23, 59, 59) &&  d.EstatuaBolsa == estatus);
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
