using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys.Select
{
    public class TiposSlidersSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoSlider> SelectCityApp = new SelectCityApp<TipoSlider>();

        public TiposSlidersSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoSlider>> SelectTiposSliders()
        {
            Response<IEnumerable<TipoSlider>> response = new Response<IEnumerable<TipoSlider>>();

            try
            {
                response.Data = CityAppContext.TiposSliders;

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
