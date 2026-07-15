using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaDependenciaLogic
{
    public class DeleteDependencia
    {
        private  DependenciaPeticiones DependenciaPeticiones;

        public DeleteDependencia(HttpClient cliente)
        {
            DependenciaPeticiones = new DependenciaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idDependencia)
        {
            Response<object> response = await DependenciaPeticiones.eliminarDependencia(token, idDependencia);
            return response;
        }
    }
}
