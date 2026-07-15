using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SliderLogic
{
    public class ConsultarSlidersLogic
    {
        private SliderQuerys SliderQuerys;
        private ArchivoSliderQuerys ArchivoSliderQuerys;
        private TipoSliderQuerys TipoSliderQuerys;
        private List<Slider> Sliders;

        public ConsultarSlidersLogic(CityAppContext cityAppContetx)
        {
            SliderQuerys = new SliderQuerys(cityAppContetx);
            ArchivoSliderQuerys = new ArchivoSliderQuerys(cityAppContetx);
            TipoSliderQuerys = new TipoSliderQuerys(cityAppContetx);
        }

        public Response<List<Slider>> Consultar()
        {
            Response<List<Slider>> response = new Response<List<Slider>>();

            Response<IEnumerable<Slider>> responseSliders = SliderQuerys.SelectSliders();
            response.Status = responseSliders.Status;
            if (response.Status.Exito == 1)
            {
                Sliders = responseSliders.Data.ToList();
                for(int i = 0; i < Sliders.Count; i++)
                {
                    Response<TipoSlider> responseTipoSlider = TipoSliderQuerys.SelectTipoSlider(Sliders[i].IdTipoSlider);
                    response.Status = responseTipoSlider.Status;
                    if (response.Status.Exito == 1)
                    {
                        Sliders[i].TipoSlider = responseTipoSlider.Data;
                    }
                }
                Response<object> responseCargarListas = CargarListas();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = Sliders;
                    response.Info = responseSliders.Info;
                }
            }

            return response;
        }

        private Response<object> CargarListas()
        {

            Response<object> response = new Response<object>();
            for(int i = 0; i < Sliders.Count; i++)
            {
                Response<IEnumerable<ArchivoSlider>> responseArchivosSlider = new Response<IEnumerable<ArchivoSlider>>();
                responseArchivosSlider = ArchivoSliderQuerys.SelectArchivosSliderIdSlider(Sliders[i].IdSlider);
                response.Status = responseArchivosSlider.Status;
                if(response.Status.Exito == 1)
                {
                    Sliders[i].ArchivosSlider = new List<ArchivoSlider>();
                    Sliders[i].ArchivosSlider = responseArchivosSlider.Data.ToList();
                }
                else if (response.Status.Exito == 2)
                {
                    response.Status.Exito = 1;
                }
            }
            return response;
        }
    }
}
