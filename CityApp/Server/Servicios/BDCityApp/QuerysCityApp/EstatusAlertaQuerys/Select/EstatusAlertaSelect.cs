using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusAlertaQuerys.Select
{
    public class EstatusAlertaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EstatusAlerta> SelectCityApp = new SelectCityApp<EstatusAlerta>();

        public EstatusAlertaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<EstatusAlerta>> SelectEstatusAlertaSelect()
        {
            Response<IEnumerable<EstatusAlerta>> response = new Response<IEnumerable<EstatusAlerta>>();

            try
            {
                response.Data = CityAppContext.EstatusAlertas;

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
