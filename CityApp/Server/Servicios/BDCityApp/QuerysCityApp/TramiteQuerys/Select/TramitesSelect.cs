using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Select
{
    public class TramitesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Tramite> SelectCityApp = new SelectCityApp<Tramite>();

        private Paginado<Tramite> Paginado = new Paginado<Tramite>();

        public TramitesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<IEnumerable<Tramite>> SelectTramites(int idDependencia)
        {
            Response<IEnumerable<Tramite>> response = new Response<IEnumerable<Tramite>>();

            try
            {
                response.Data = CityAppContext.Tramites.Where(d => d.IdDependencia == idDependencia);
                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }

        public Response<IEnumerable<Tramite>> SelectTramiteFirltoTramite(FiltroTramite filtroTramite)
        {
            Response<IEnumerable<Tramite>> response = new Response<IEnumerable<Tramite>>();

            try
            {
                response.Data = CityAppContext.Tramites;

                if (filtroTramite.IdTipoTramite != 0)
                {
                    response.Data = response.Data.Where(d => d.IdTipoTramite == filtroTramite.IdTipoTramite);
                }
                if (filtroTramite.IdSecretaria != 0 && filtroTramite.IdsDependencias != null)
                {
                    response.Data = response.Data.Where(d => filtroTramite.IdsDependencias.Contains(d.IdDependencia));
                }
                else if(filtroTramite.IdSecretaria != 0 && filtroTramite.IdsDependencias == null)
                {
                    response.Data = response.Data.Where(d => d.IdDependencia == -1);
                }
                if (filtroTramite.IdDependencia != 0)
                {
                    response.Data = response.Data.Where(d => d.IdDependencia == filtroTramite.IdDependencia);
                }
                if (filtroTramite.Concepto != "NA")
                {
                    response.Data = response.Data.Where(d => d.Concepto.Contains(filtroTramite.Concepto));
                }
                if (filtroTramite.Descripcion != "NA")
                {
                    response.Data = response.Data.Where(d => d.Descripcion.Contains(filtroTramite.Descripcion));
                }
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroTramite.MaximoElementos, filtroTramite.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Tramite>> SelectTramiteTiposTramites(int idTipoTramite, FechasDashBoard fechasDashBoard)
        {
            Response<IEnumerable<Tramite>> response = new Response<IEnumerable<Tramite>>();

            try
            {
                response.Data = from data in CityAppContext.Tramites
                                where data.IdTipoTramite == idTipoTramite
                                select new Tramite()
                                {
                                    IdTramite = data.IdTramite,
                                    Concepto = data.Concepto,
                                    Descripcion = data.Descripcion,
                                    Direccion = data.Direccion,
                                    Telefono = data.Descripcion,
                                    Requisitos = data.Descripcion,
                                    Costo = data.Costo,
                                    Latitud = data.Latitud,
                                    IdDependencia = data.IdDependencia,
                                    IdTipoTramite = data.IdTipoTramite,
                                    Observaciones = data.Observaciones, 
                                    
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
