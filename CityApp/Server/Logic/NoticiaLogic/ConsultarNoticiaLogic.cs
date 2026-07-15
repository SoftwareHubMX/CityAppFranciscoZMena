using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NoticiaLogic
{
    public class ConsultarNoticiaLogic
    {
        private NoticiaQuerys NoticiaQuerys;
        private ArchivoNoticiaQuerys ArchivoNoticiaQuerys;

        private int IdNoticia;
        private Noticia Noticia;

        public ConsultarNoticiaLogic(CityAppContext cityAppContetx, int idNoticia)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContetx);
            ArchivoNoticiaQuerys = new ArchivoNoticiaQuerys(cityAppContetx);

            IdNoticia = idNoticia;
        }

        public Response<Noticia> Consultar()
        {
            Response<Noticia> response = new Response<Noticia>();

            response = NoticiaQuerys.SelectNoticiaIdNoticia(IdNoticia);
            if (response.Status.Exito == 1)
            {
                Noticia = response.Data;
                Response<object> responseCargarListas = CargarArchivos();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = Noticia;
                }
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoNoticia>> responseArchivoNoticia = ArchivoNoticiaQuerys.SelectArchivosNoticiaIdNoticia(IdNoticia);
            response.Status = responseArchivoNoticia.Status;
            if (response.Status.Exito == 1)
            {
                Noticia.ArchivosNoticia = responseArchivoNoticia.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
