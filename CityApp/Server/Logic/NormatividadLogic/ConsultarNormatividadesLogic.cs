using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class ConsultarNormatividadesLogic
    {
        private NormatividadQuerys NormatividadQuerys;

        public ConsultarNormatividadesLogic(CityAppContext cityAppContext)
        {
            NormatividadQuerys = new NormatividadQuerys(cityAppContext);
        }

        public Response<List<Normatividad>> Consultar()
        {
            Response<List<Normatividad>> response = new Response<List<Normatividad>>();

            Response<IEnumerable<Normatividad>> responseNormatividades = new Response<IEnumerable<Normatividad>>();
            responseNormatividades = NormatividadQuerys.SelectNormatividades();
            response.Status = responseNormatividades.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Normatividad>();
                response.Data = responseNormatividades.Data.ToList();
            }
            return response;
        }
    }
}
