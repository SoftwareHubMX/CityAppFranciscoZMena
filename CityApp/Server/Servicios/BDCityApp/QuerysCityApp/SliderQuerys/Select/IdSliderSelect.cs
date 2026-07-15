using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Select
{
    public class IdSliderSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdSliderSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectUltimoIdSliderTexto(string texto)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.Sliders
                                 orderby data.IdSlider
                                 where data.Titulo == texto
                                 select data.IdSlider).LastOrDefault();

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
