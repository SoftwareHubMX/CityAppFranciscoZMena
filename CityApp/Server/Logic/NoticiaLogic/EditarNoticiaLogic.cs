using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NoticiaLogic
{
    public class EditarNoticiaLogic
    {
        private NoticiaQuerys NoticiaQuerys;

        private Noticia Noticia;

        public EditarNoticiaLogic(CityAppContext cityAppContext, Noticia noticia)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContext);

            Noticia = noticia;
        }

        public Response<object> Editar()
        {
            Response<object> response = new Response<object>();

            response = NoticiaQuerys.UpdateNoticia(Noticia);

            return response;
        }
    }
}
