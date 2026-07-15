using CityApp.Client.Services.ApiRest.NormatividadPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaNormatividadLogic
{
    public class SelectNormatividades
    {
        private NormatividadPeticiones NormatividadPeticiones;

        public SelectNormatividades(HttpClient cliente)
        {
            NormatividadPeticiones = new NormatividadPeticiones(cliente);
        }

        public async Task<Response<List<Normatividad>>> SelectAll(string token)
        {
            Response<List<Normatividad>> response = await NormatividadPeticiones.consultarNormatividads(token);
            return response;
        }
    }
}
