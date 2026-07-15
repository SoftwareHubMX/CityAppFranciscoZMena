using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Select
{
    public class AlertasRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<AlertaRuta> SelectCityApp = new SelectCityApp<AlertaRuta>();
        private Paginado<AlertaRuta> Paginado = new Paginado<AlertaRuta>();

        public AlertasRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<AlertaRuta>> SelectAlertasRuta(int idRutaRecoleccion)
        {
            Response<IEnumerable<AlertaRuta>> response = new Response<IEnumerable<AlertaRuta>>();

            try
            {
                
                
                response.Data = from data in CityAppContext.AlertasRutas
                orderby data.IdAlertaRuta
                where data.IdRutaRecoleccion == idRutaRecoleccion
                select new AlertaRuta()
                {
                    IdAlertaRuta = data.IdAlertaRuta,
                    FechaAlerta = data.FechaAlerta,
                    IdTipoAlertaRuta = data.IdTipoAlertaRuta,
                    TiposAlertaRuta = data.TiposAlertaRuta,
                    IdStatusAlertaRuta = data.IdStatusAlertaRuta,
                    StatusAlertaRuta = data.StatusAlertaRuta,
                    IdRutaRecoleccion = data.IdRutaRecoleccion,
                    RutaRecoleccion = data.RutaRecoleccion
                };
                
                
                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<AlertaRuta>> SelectAlertasRutaFirltoAlertaRuta(FiltroAlertaRuta filtroAlertaRuta)
        {
            Response<IEnumerable<AlertaRuta>> response = new Response<IEnumerable<AlertaRuta>>();

            try
            {
                response.Data = CityAppContext.AlertasRutas;
                if (filtroAlertaRuta.IdTipoAlertaRuta != 0)
                {
                    response.Data = response.Data.Where(d => d.IdTipoAlertaRuta == filtroAlertaRuta.IdTipoAlertaRuta);
                }
                if (filtroAlertaRuta.IdStatusAlertaRuta != 0)
                {
                    response.Data = response.Data.Where(d => d.IdStatusAlertaRuta == filtroAlertaRuta.IdStatusAlertaRuta);
                }
                if (filtroAlertaRuta.IdRutaRecoleccion != 0)
                {
                    response.Data = response.Data.Where(d => d.IdRutaRecoleccion == filtroAlertaRuta.IdRutaRecoleccion);
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroAlertaRuta.MaximoElementos, filtroAlertaRuta.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
