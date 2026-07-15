using CityApp.Client.Services.ApiRest.ArchivoSliderPeticioens;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaSliderLogic
{
    public class DownloadArchivoSlider
    {
        private ArchivoSliderPeticioens ArchivoSliderPeticioens;

        public DownloadArchivoSlider(HttpClient cliente)
        {
            ArchivoSliderPeticioens = new ArchivoSliderPeticioens(cliente);
        }

        public async Task<Response<byte[]>> Download(string imagen, int idSlider)
        {
            Response<byte[]> response = await ArchivoSliderPeticioens.descargarArchivoSlider(imagen, idSlider);
            return response;
        }
    }
}
