using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys.Select
{
    public class TipoSliderSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoSlider> SelectCityApp = new SelectCityApp<TipoSlider>();

        public TipoSliderSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoSlider> SelectTipoSlider(int idTipoSlider)
        {
            Response<TipoSlider> response = new Response<TipoSlider>();

            try
            {
                response.Data = CityAppContext.TiposSliders.Where(d => d.IdTipoSlider == idTipoSlider).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
