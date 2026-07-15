using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SliderLogic
{
    public class ConsultarSliderAppLogic
    {
        private SliderQuerys SliderQuerys;
        private ArchivoSliderQuerys ArchivoSliderQuerys;
        private TipoSliderQuerys TipoSliderQuerys;

        private int IdTipoSlider;
        private int IdSlider;
        private Slider Slider;

        public ConsultarSliderAppLogic(CityAppContext cityAppContetx, int idTipoSlider)
        {
            SliderQuerys = new SliderQuerys(cityAppContetx);
            ArchivoSliderQuerys = new ArchivoSliderQuerys(cityAppContetx);
            TipoSliderQuerys = new TipoSliderQuerys(cityAppContetx);

            IdTipoSlider = idTipoSlider;
        }

        public Response<Slider> Consultar()
        {
            Response<Slider> response = new Response<Slider>();

            response = SliderQuerys.SelectSliderIdTipoSlider(IdTipoSlider);
            if (response.Status.Exito == 1)
            {
                Slider = response.Data;
                IdSlider = Slider.IdSlider;
                Response<TipoSlider> responseTipoSlider = TipoSliderQuerys.SelectTipoSlider(IdTipoSlider);
                response.Status = responseTipoSlider.Status;
                if(response.Status.Exito == 1)
                {
                    Slider.TipoSlider = responseTipoSlider.Data;
                }
                Response<object> responseCargarListas = CargarArchivos();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = Slider;
                }
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoSlider>> responseArchivoSlider = ArchivoSliderQuerys.SelectArchivosSliderIdSlider(IdSlider);
            response.Status = responseArchivoSlider.Status;
            if (response.Status.Exito == 1)
            {
                Slider.ArchivosSlider = responseArchivoSlider.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
