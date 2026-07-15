using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Select
{
    public class ArchivoSliderSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoSlider> SelectCityApp = new SelectCityApp<ArchivoSlider>();

        public ArchivoSliderSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ArchivoSlider> SelectArchivoSliderIdArchivoSlider(int idArchivoSlider)
        {
            Response<ArchivoSlider> response = new Response<ArchivoSlider>();

            try
            {
                response.Data = CityAppContext.ArchivosSlider.Where(d => d.IdArchivoSlider == idArchivoSlider).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoSlider> SelectArchivoSliderIdSliderPrincipal(int idSlider)
        {
            Response<ArchivoSlider> response = new Response<ArchivoSlider>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivosSlider
                                 where data.IdSlider == idSlider
                                 && data.Principal == true
                                 select new ArchivoSlider()
                                 {
                                     IdArchivoSlider = data.IdArchivoSlider,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdSlider = data.IdSlider,
                                     Slider = null,
                                 }).First();


                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoSlider> SelectArchivoSliderIdSliderFirst(int idSlider)
        {
            Response<ArchivoSlider> response = new Response<ArchivoSlider>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivosSlider
                                 where data.IdSlider == idSlider
                                 select new ArchivoSlider()
                                 {
                                     IdArchivoSlider = data.IdArchivoSlider,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdSlider = data.IdSlider,
                                     Slider = null,
                                 }).First();

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
