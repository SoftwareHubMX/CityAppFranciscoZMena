using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NoticiaLogic
{
    public class CrearNoticiaLogic
    {
        private NoticiaQuerys NoticiaQuerys;

        private Noticia Noticia;

        public CrearNoticiaLogic(CityAppContext cityAppContext, Noticia noticia)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContext);

            Noticia = noticia;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseNoticia = NoticiaQuerys.InsertNoticia(Noticia);
            response.Status = responseNoticia.Status;
            if (response.Status.Exito == 1)
            {
                response = NoticiaQuerys.SelectUltimoIdNoticiaTexto(Noticia.Texto);
            }

            return response;
        }
    }
}
