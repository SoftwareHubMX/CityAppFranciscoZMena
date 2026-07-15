using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.AnuncioPeticiones
{
    public class AnuncioPeticiones
    {
        private CrearAnuncio CrearAnuncio;
        private EliminarAnuncio EliminarAnuncio;
        private EditarAnuncio EditarAnuncio;
        private ConsultarAnuncio ConsultarAnuncio;
        private ConsultarAnuncios ConsultarAnuncios;

        public AnuncioPeticiones(HttpClient cliente)
        {
            CrearAnuncio = new CrearAnuncio(cliente);
            EliminarAnuncio = new EliminarAnuncio(cliente);
            EditarAnuncio = new EditarAnuncio(cliente);
            ConsultarAnuncio = new ConsultarAnuncio(cliente);
            ConsultarAnuncios = new ConsultarAnuncios(cliente);
        }

        public async Task<Response<int>> crearAnuncio(string token, Anuncio anuncio)
        {
            Response<int> response = await CrearAnuncio.CrearAnuncioAsync(token, anuncio);
            return response;
        }
        public async Task<Response<object>> eliminarAnuncio(string token, int idAnuncio)
        {
            Response<object> response = await EliminarAnuncio.EliminarAnuncioAsync(token, idAnuncio);
            return response;
        }

        public async Task<Response<object>> editarAnuncioo(string token, Anuncio anuncio)
        {
            Response<object> response = await EditarAnuncio.EditarAnuncioAsync(token, anuncio);
            return response;
        }
        public async Task<Response<Anuncio>> consultarAnuncio(int idAnuncio)
        {
            Response<Anuncio> response = await ConsultarAnuncio.ConsultarAnuncioAsync(idAnuncio);
            return response;
        }
        public async Task<Response<List<Anuncio>>> consultarAnuncios(string token, FiltroAnuncio filtroAnuncio)
        {
            Response<List<Anuncio>> response = await ConsultarAnuncios.ConsultarAnunciosAsync(token, filtroAnuncio);
            return response;
        }
    }
}
