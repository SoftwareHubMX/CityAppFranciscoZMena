using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Select
{
    public class AlertaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Alerta> SelectCityApp = new SelectCityApp<Alerta>();

        public AlertaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Alerta> SelectAlertaIdAlerta(int idAlerta)
        {
            Response<Alerta> response = new Response<Alerta>();

            try
            {
                response.Data = (from data in CityAppContext.Alertas
                                orderby data.IdAlerta
                                where data.IdAlerta == idAlerta
                                select new Alerta()
                                {
                                    IdAlerta = data.IdAlerta,
                                    FechaAlerta = data.FechaAlerta,
                                    IdCuenta = data.IdCuenta,
                                    Cuenta = data.Cuenta,
                                    DireccionAlerta = data.DireccionAlerta,
                                    IdEstatusAlerta = data.IdEstatusAlerta,
                                    EstatusAlerta = data.EstatusAlerta
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
