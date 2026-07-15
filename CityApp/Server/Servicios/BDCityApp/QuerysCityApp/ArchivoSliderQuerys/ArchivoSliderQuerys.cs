using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys
{
    public class ArchivoSliderQuerys
    {
        private ArchivoSliderInsert ArchivoSliderInsert;
        private ArchivoSliderelect ArchivoSliderelect;
        private ArchivoSliderSelect ArchivoSliderSelect;
        private ArchivoSliderDelete ArchivoSliderDelete;
        private ArchivosSlidersDelete ArchivosSliderDelete;

        public ArchivoSliderQuerys(CityAppContext cityAppContext)
        {
            ArchivoSliderInsert = new ArchivoSliderInsert(cityAppContext);
            ArchivoSliderelect = new ArchivoSliderelect(cityAppContext);
            ArchivoSliderSelect = new ArchivoSliderSelect(cityAppContext);
            ArchivoSliderDelete = new ArchivoSliderDelete(cityAppContext);
            ArchivosSliderDelete = new ArchivosSlidersDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertArchivoSlider(ArchivoSlider ArchivoSlider)
        {
            return ArchivoSliderInsert.InsertArchivoSlider(ArchivoSlider);
        }

        //select
        public Response<IEnumerable<ArchivoSlider>> SelectArchivosSliderIdSlider(int idSlider)
        {
            return ArchivoSliderelect.SelectArchivosSliderIdSlider(idSlider);
        }
        public Response<ArchivoSlider> SelectArchivoSliderIdArchivoSlider(int idArchivoSlider)
        {
            return ArchivoSliderSelect.SelectArchivoSliderIdArchivoSlider(idArchivoSlider);
        }
        public Response<ArchivoSlider> SelectArchivoSliderIdSliderPrincipal(int idSlider)
        {
            return ArchivoSliderSelect.SelectArchivoSliderIdSliderPrincipal(idSlider);
        }
        public Response<ArchivoSlider> SelectArchivoSliderIdSliderFirst(int idSlider)
        {
            return ArchivoSliderSelect.SelectArchivoSliderIdSliderFirst(idSlider);
        }

        //delete
        public Response<object> DeleteArchivoSlider(ArchivoSlider ArchivoSlider)
        {
            return ArchivoSliderDelete.DeleteArchivoSlider(ArchivoSlider);
        }
        public Response<object> DeleteArchivosSlider(IEnumerable<ArchivoSlider> archivosSlider)
        {
            return ArchivosSliderDelete.DeleteArchivosSliders(archivosSlider);
        }
    }
}
