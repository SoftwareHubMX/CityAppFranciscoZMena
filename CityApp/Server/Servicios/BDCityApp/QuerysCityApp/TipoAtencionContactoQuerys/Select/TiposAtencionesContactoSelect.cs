using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAtencionContactoQuerys.Select
{
    public class TiposAtencionesContactoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoAtencionContacto> SelectCityApp = new SelectCityApp<TipoAtencionContacto>();

        public TiposAtencionesContactoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoAtencionContacto>> SelectTiposAtencionesContacto()
        {
            Response<IEnumerable<TipoAtencionContacto>> response = new Response<IEnumerable<TipoAtencionContacto>>();

            try
            {
                response.Data = CityAppContext.TiposAtencionesContacto;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
