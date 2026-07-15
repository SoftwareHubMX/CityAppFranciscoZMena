using CityApp.Client.Services.ApiRest.TipoAtencionContactoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaContactoSeguridadPublicaLogic
{
    public class SelectTiposAtencionesContacto
    {
        private TipoAtencionContactoPeticiones TipoAtencionContactoPeticiones;

        public SelectTiposAtencionesContacto(HttpClient cliente)
        {
            TipoAtencionContactoPeticiones = new TipoAtencionContactoPeticiones(cliente);
        }

        public async Task<Response<List<TipoAtencionContacto>>> SelectAll()
        {
            Response<List<TipoAtencionContacto>> response = await TipoAtencionContactoPeticiones.consultarTiposAtencionesContacto();
            return response;
        }
    }
}
