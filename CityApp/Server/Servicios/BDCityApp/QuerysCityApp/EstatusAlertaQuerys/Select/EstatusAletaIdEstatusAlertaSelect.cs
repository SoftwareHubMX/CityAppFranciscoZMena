using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusAlertaQuerys.Select
{
    public class EstatusAletaIdEstatusAlertaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EstatusAlerta> SelectCityApp = new SelectCityApp<EstatusAlerta>();

        public EstatusAletaIdEstatusAlertaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<EstatusAlerta> SelectEstatusAletaIdEstatusAlertaSelect(int idEstatus)
        {
            Response<EstatusAlerta> response = new Response<EstatusAlerta>();

            try
            {
                response.Data = (from data in CityAppContext.EstatusAlertas
                                 orderby data.IdEstatusAlerta
                                 where data.IdEstatusAlerta == idEstatus
                                 select new EstatusAlerta()
                                 {
                                     IdEstatusAlerta = data.IdEstatusAlerta,
                                     Estatus = data.Estatus,
                                 }).FirstOrDefault();

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
