using CityApp.Client.Services.ApiRest.TipoAtencionContactoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoAtencionContactoPeticiones
{
    public class TipoAtencionContactoPeticiones
    {
        private ConsultarTiposAtencionesContacto ConsultarTiposAtencionesContacto;

        public TipoAtencionContactoPeticiones(HttpClient cliente)
        {
            ConsultarTiposAtencionesContacto = new ConsultarTiposAtencionesContacto(cliente);
        }

        public async Task<Response<List<TipoAtencionContacto>>> consultarTiposAtencionesContacto()
        {
            Response<List<TipoAtencionContacto>> response = await ConsultarTiposAtencionesContacto.ConsultarTiposAtencionesContactoAsync();
            return response;
        }
    }
}
