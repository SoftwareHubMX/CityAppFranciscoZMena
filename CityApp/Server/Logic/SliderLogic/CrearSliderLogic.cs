using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SliderLogic
{
    public class CrearSliderLogic
    {
        private SliderQuerys SliderQuerys;

        private Slider Slider;

        public CrearSliderLogic(CityAppContext cityAppContext, Slider slider)
        {
            SliderQuerys = new SliderQuerys(cityAppContext);

            Slider = slider;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();
            Response<Slider> responseSliderSelect = new Response<Slider>();
            responseSliderSelect = SliderQuerys.SelectSliderIdTipoSlider(Slider.IdTipoSlider);
            response.Status  = responseSliderSelect.Status;
            if(response.Status.Exito != 1)
            {
                Response<object> responseSlider = SliderQuerys.InsertSlider(Slider);
                response.Status = responseSlider.Status;
                if (response.Status.Exito == 1)
                {
                    response = SliderQuerys.SelectUltimoIdSliderTexto(Slider.Titulo);
                }
            }
            else
            {
                response.Data = responseSliderSelect.Data.IdSlider;
            }
            

            return response;
        }
    }
}
