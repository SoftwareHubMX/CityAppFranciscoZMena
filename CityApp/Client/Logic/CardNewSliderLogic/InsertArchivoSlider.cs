using CityApp.Client.Services.ApiRest.ArchivoSliderPeticioens;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewSliderLogic
{
    public class InsertArchivoSlider
    {
        private ArchivoSliderPeticioens ArchivoSliderPeticioens;

        public InsertArchivoSlider(HttpClient cliente)
        {
            ArchivoSliderPeticioens = new ArchivoSliderPeticioens(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idSlider, string token)
        {
            Response<string> response = await ArchivoSliderPeticioens.agregarArchivoSlider(content, idSlider, token);
            return response;
        }
    }
}
