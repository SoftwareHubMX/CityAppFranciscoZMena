using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoCitaQuerys.Select
{
    public class TiposCitaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoCita> SelectCityApp = new SelectCityApp<TipoCita>();

        public TiposCitaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoCita>> SelectTiposCita()
        {
            Response<IEnumerable<TipoCita>> response = new Response<IEnumerable<TipoCita>>();

            try
            {
                response.Data = CityAppContext.TiposCita;

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
