using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Select
{
    public class NoticiaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Noticia> SelectCityApp = new SelectCityApp<Noticia>();

        public NoticiaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Noticia> SelectNoticiaIdNoticia(int idNoticia)
        {
            Response<Noticia> response = new Response<Noticia>();

            try
            {
                response.Data = CityAppContext.Noticias.Where(d => d.IdNoticia == idNoticia).First();

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
