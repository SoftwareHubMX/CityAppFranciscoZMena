using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoSliderPeticioens
{
    public class ArchivoSliderPeticioens
    {
        private AgregarArchivoSlider AgregarArchivoSlider;
        private DescargarArchivoSlider DescargarArchivoSlider;
        private EliminarArchivoSlider EliminarArchivoSlider;

        public ArchivoSliderPeticioens(HttpClient cliente)
        {
            AgregarArchivoSlider = new AgregarArchivoSlider(cliente);
            DescargarArchivoSlider = new DescargarArchivoSlider(cliente);
            EliminarArchivoSlider = new EliminarArchivoSlider(cliente);
        }

        public async Task<Response<string>> agregarArchivoSlider(MultipartFormDataContent content, int idSlider, string token)
        {
            Response<string> response = await AgregarArchivoSlider.AgregarArchivoSliderAsync(content, idSlider, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoSlider(string imagen, int idSlider)
        {
            Response<byte[]> response = await DescargarArchivoSlider.DescargarArchivoSliderAsync(imagen, idSlider);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoSlider(string token, int idArchivoSlider)
        {
            Response<object> response = await EliminarArchivoSlider.EliminarArchivoSliderAsync(token, idArchivoSlider);
            return response;
        }
    }
}
