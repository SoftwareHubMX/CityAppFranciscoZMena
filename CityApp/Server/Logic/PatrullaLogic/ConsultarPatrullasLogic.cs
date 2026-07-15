using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PatrullaLogic
{
    public class ConsultarPatrullasLogic
    {
        private PatrullaQuerys PatrullaQuerys;
        private FiltroPatrullas FiltroPatrullas = new FiltroPatrullas();

        public ConsultarPatrullasLogic(CityAppContext cityAppContext, FiltroPatrullas filtroPatrullas)
        {
            PatrullaQuerys = new PatrullaQuerys(cityAppContext);

            FiltroPatrullas = filtroPatrullas;
        }

        public Response<List<Patrulla>> Consultar()
        {
            Response<List<Patrulla>> response = new Response<List<Patrulla>>();

            Response<IEnumerable<Patrulla>> responsePatrullas = new Response<IEnumerable<Patrulla>>();
            responsePatrullas = PatrullaQuerys.SelectPatrullaFiltroPatrulla(FiltroPatrullas);
            response.Status = responsePatrullas.Status;
            if(response.Status.Exito == 1)
            {
                response.Data = new List<Patrulla>();
                response.Data = responsePatrullas.Data.ToList();
                response.Info = responsePatrullas.Info;
            }
            return response;
        }
    }
}
