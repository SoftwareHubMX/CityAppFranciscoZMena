using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AnuncioLogic
{
    public class EditarAnuncioLogic
    {
        private AnuncioQuerys AnuncioQuerys;

        private Anuncio Anuncio;

        public EditarAnuncioLogic(CityAppContext cityAppContext, Anuncio anuncio)
        {
            AnuncioQuerys = new AnuncioQuerys(cityAppContext);

            Anuncio = anuncio;
        }

        public Response<object> Editar()
        {
            Response<object> response = new Response<object>();

            response = AnuncioQuerys.UpdateAnuncio(Anuncio);

            return response;
        }
    }
}
