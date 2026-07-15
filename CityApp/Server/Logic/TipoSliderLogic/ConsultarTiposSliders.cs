using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoSliderLogic
{
    public class ConsultarTiposSliders
    {
        private TipoSliderQuerys TipoSliderQuerys;

        public ConsultarTiposSliders(CityAppContext cityAppContext)
        {
            TipoSliderQuerys = new TipoSliderQuerys(cityAppContext);
        }

        public Response<List<TipoSlider>> Consultar()
        {
            Response<List<TipoSlider>> response = new Response<List<TipoSlider>>();

            Response<IEnumerable<TipoSlider>> responseTipoSlider = TipoSliderQuerys.SelectTiposSliders();
            response.Status = responseTipoSlider.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoSlider.Data.ToList();
            }
            return response;
        }

    }
}
