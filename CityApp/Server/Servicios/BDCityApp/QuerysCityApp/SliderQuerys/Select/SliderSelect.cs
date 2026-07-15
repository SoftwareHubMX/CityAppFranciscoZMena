using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Select
{
    public class SliderSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Slider> SelectCityApp = new SelectCityApp<Slider>();

        public SliderSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Slider> SelectSliderIdSlider(int idSlider)
        {
            Response<Slider> response = new Response<Slider>();

            try
            {
                response.Data = CityAppContext.Sliders.Where(d => d.IdSlider == idSlider).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Slider> SelectSliderIdTipoSlider(int idTipoSlider)
        {
            Response<Slider> response = new Response<Slider>();

            try
            {
                response.Data = CityAppContext.Sliders.Where(d => d.IdTipoSlider == idTipoSlider).FirstOrDefault();

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
