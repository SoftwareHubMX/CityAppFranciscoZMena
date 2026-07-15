using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Select
{
    public class SlidersSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Slider> SelectCityApp = new SelectCityApp<Slider>();

        private Paginado<Slider> Paginado = new Paginado<Slider>();

        public SlidersSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Slider>> SelectSliders()
        {
            Response<IEnumerable<Slider>> response = new Response<IEnumerable<Slider>>();

            try
            {
                 response.Data = CityAppContext.Sliders;

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
