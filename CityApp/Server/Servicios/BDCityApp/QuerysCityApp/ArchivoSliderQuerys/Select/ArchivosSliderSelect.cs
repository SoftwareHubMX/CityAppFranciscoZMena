using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Select
{
    public class ArchivoSliderelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoSlider> SelectCityApp = new SelectCityApp<ArchivoSlider>();

        public ArchivoSliderelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoSlider>> SelectArchivosSliderIdSlider(int idSlider)
        {
            Response<IEnumerable<ArchivoSlider>> response = new Response<IEnumerable<ArchivoSlider>>();

            try
            {
                response.Data = from data in CityAppContext.ArchivosSlider
                                where data.IdSlider == idSlider
                                select new ArchivoSlider()
                                {
                                    IdArchivoSlider = data.IdArchivoSlider,
                                    Ruta = data.Ruta,
                                    Formato = data.Formato,
                                    Principal = data.Principal,
                                    IdSlider = data.IdSlider
                                };

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
