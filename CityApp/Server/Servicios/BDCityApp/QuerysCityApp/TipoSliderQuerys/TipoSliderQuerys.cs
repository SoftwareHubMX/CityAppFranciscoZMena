using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSliderQuerys
{
    public class TipoSliderQuerys
    {
        private TiposSlidersSelect TiposSlidersSelect;
        private TipoSliderSelect TipoSliderSelect;

        public TipoSliderQuerys(CityAppContext cityAppContext)
        {
            TiposSlidersSelect = new TiposSlidersSelect(cityAppContext);
            TipoSliderSelect = new TipoSliderSelect(cityAppContext);
        }

        public Response<IEnumerable<TipoSlider>> SelectTiposSliders()
        {
            return TiposSlidersSelect.SelectTiposSliders();
        }

        public Response<TipoSlider> SelectTipoSlider(int idTipoSlider)
        {
            return TipoSliderSelect.SelectTipoSlider(idTipoSlider);
        }
    }
}
