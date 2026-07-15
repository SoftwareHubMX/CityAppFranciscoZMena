using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys.Select
{
    public class AlertasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Alerta> SelectCityApp = new SelectCityApp<Alerta>();

        public AlertasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Alerta>> SelectAlertas(int idEstatusAlerta)
        {
            Response<IEnumerable<Alerta>> response = new Response<IEnumerable<Alerta>>();

            try
            {
                if(idEstatusAlerta != 0)
                {
                    response.Data = from data in CityAppContext.Alertas
                                    orderby data.IdAlerta
                                    where data.IdEstatusAlerta == idEstatusAlerta
                                    select new Alerta()
                                    {
                                        IdAlerta = data.IdAlerta,
                                        FechaAlerta = data.FechaAlerta,
                                        IdCuenta = data.IdCuenta,
                                        Cuenta = data.Cuenta,
                                        DireccionAlerta = data.DireccionAlerta,
                                        IdEstatusAlerta = data.IdEstatusAlerta,
                                        EstatusAlerta = data.EstatusAlerta
                                    };
                }
                else
                {
                    response.Data = from data in CityAppContext.Alertas
                                    orderby data.IdAlerta
                                    select new Alerta()
                                    {
                                        IdAlerta = data.IdAlerta,
                                        FechaAlerta = data.FechaAlerta,
                                        IdCuenta = data.IdCuenta,
                                        Cuenta = data.Cuenta,
                                        DireccionAlerta = data.DireccionAlerta,
                                        IdEstatusAlerta = data.IdEstatusAlerta,
                                        EstatusAlerta = data.EstatusAlerta
                                    };
                }
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
