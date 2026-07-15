using CityApp.Client.Services.ApiRest.PostulacionPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaPostulacionLogic
{
    public class SelectFiltroPostulacionesLogic
    {
        private PostulacionPeticiones PostulacionPeticiones;

        public SelectFiltroPostulacionesLogic(HttpClient cliente)
        {
            PostulacionPeticiones = new PostulacionPeticiones(cliente);
        }

        public async Task<Response<List<Postulacion>>> SelectAll(string token, FiltroPostulacion filtroPostulacion)
        {
            Response<List<Postulacion>> response = await PostulacionPeticiones.consultarFiltroPostulaciones(token, filtroPostulacion);
            return response;
        }
    }
}
