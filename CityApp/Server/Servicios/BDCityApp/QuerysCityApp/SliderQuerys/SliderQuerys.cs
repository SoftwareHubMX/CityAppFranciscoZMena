using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys
{
    public class SliderQuerys
    {
        private SliderInsert SliderInsert;
        private SliderSelect SliderSelect;
        private SlidersSelect SlidersSelect;
        private IdSliderSelect IdSliderSelect;
        private SliderUpdate SliderUpdate;
        private SliderDelete SliderDelete;

        public SliderQuerys(CityAppContext cityAppContext)
        {
            SliderInsert = new SliderInsert(cityAppContext);
            SliderSelect = new SliderSelect(cityAppContext);
            SlidersSelect = new SlidersSelect(cityAppContext);
            IdSliderSelect = new IdSliderSelect(cityAppContext);
            SliderUpdate = new SliderUpdate(cityAppContext);
            SliderDelete = new SliderDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertSlider(Slider Slider)
        {
            return SliderInsert.InsertSlider(Slider);
        }

        //select
        public Response<Slider> SelectSliderIdSlider(int idSlider)
        {
            return SliderSelect.SelectSliderIdSlider(idSlider);
        }
        public Response<Slider> SelectSliderIdTipoSlider(int idTipoSlider)
        {
            return SliderSelect.SelectSliderIdTipoSlider(idTipoSlider);
        }
        public Response<IEnumerable<Slider>> SelectSliders()
        {
            return SlidersSelect.SelectSliders();
        }
        public Response<int> SelectUltimoIdSliderTexto(string texto)
        {
            return IdSliderSelect.SelectUltimoIdSliderTexto(texto);
        }

        //update
        public Response<object> UpdateSlider(Slider Slider)
        {
            return SliderUpdate.UpdateSlider(Slider);
        }

        //delete
        public Response<object> DeleteSlider(Slider Slider)
        {
            return SliderDelete.DeleteSlider(Slider);
        }
    }
}
