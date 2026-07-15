using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoTramiteQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TramiteLogic
{
    public class ConsultarTramitesFiltroLogic
    {
        private TramiteQuerys TramiteQuerys;
        private DependenciaQuerys DependenciaQuerys;
        private TipoTramiteQuerys TipoTramiteQuerys;

        private FiltroTramite FiltroTramite;
        private List<Tramite> Tramite;

        public ConsultarTramitesFiltroLogic(CityAppContext cityAppContetx, FiltroTramite filtroTramite)
        {
            TramiteQuerys = new TramiteQuerys(cityAppContetx);
            DependenciaQuerys = new DependenciaQuerys(cityAppContetx);
            TipoTramiteQuerys = new TipoTramiteQuerys(cityAppContetx);
            FiltroTramite = filtroTramite;
        }
        public Response<List<Tramite>> Consultar()
        {
            Response<List<Tramite>> response = new Response<List<Tramite>>();

            if(FiltroTramite.IdSecretaria != 0)
            {
                Response<IEnumerable<int>> responseIdsDependencias = new Response<IEnumerable<int>>();
                responseIdsDependencias = DependenciaQuerys.SelectIdsDependenciasIdSecretaria(FiltroTramite.IdSecretaria);
                if(responseIdsDependencias.Status.Exito == 1)
                {
                    FiltroTramite.IdsDependencias = new List<int>();
                    FiltroTramite.IdsDependencias = responseIdsDependencias.Data.ToList();
                }
            }

            Response<IEnumerable<Tramite>> responseTramite = TramiteQuerys.SelectTramiteFirltoTramite(FiltroTramite);
            response.Status = responseTramite.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Tramite>();
                response.Data = responseTramite.Data.ToList();
                response.Info = new Info();
                response.Info = responseTramite.Info;
                for (int i = 0; i < response.Data.Count; i++)
                {
                    Response<TipoTramite> responseTipoTramite = new Response<TipoTramite>();
                    responseTipoTramite = TipoTramiteQuerys.SelectTipoTramite(response.Data[i].IdTipoTramite);
                    if(response.Status.Exito == 1)
                    {
                        response.Data[i].TipoTramite = new TipoTramite();
                        response.Data[i].TipoTramite = responseTipoTramite.Data;
                    }
                }
               
            }
            return response;
        }
    }
}
