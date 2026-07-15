using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AnuncioLogic
{
    public class CrearAnuncioLogic
    {
        private AnuncioQuerys AnuncioQuerys;

        private Anuncio Anuncio;

        public CrearAnuncioLogic(CityAppContext cityAppContext, Anuncio anuncio)
        {
            AnuncioQuerys = new AnuncioQuerys(cityAppContext);

            Anuncio = anuncio;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseSlider = AnuncioQuerys.InsertAnuncio(Anuncio);
            response.Status = responseSlider.Status;
            if (response.Status.Exito == 1)
            {
                response = AnuncioQuerys.SelectIdAnuncioTitulo(Anuncio.Titulo);
            }

            return response;
        }
    }
}
