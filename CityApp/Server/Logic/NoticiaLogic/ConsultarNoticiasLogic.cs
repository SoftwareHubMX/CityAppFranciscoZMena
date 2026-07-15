using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NoticiaLogic
{
    public class ConsultarNoticiasLogic
    {
        private NoticiaQuerys NoticiaQuerys;
        private ArchivoNoticiaQuerys ArchivoNoticiaQuerys;

        private FiltroNoticias FiltroNoticias;
        private List<Noticia> Noticias;

        public ConsultarNoticiasLogic(CityAppContext cityAppContetx, FiltroNoticias filtroNoticias)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContetx);
            ArchivoNoticiaQuerys = new ArchivoNoticiaQuerys(cityAppContetx);

            FiltroNoticias = filtroNoticias;
        }

        public Response<List<Noticia>> Consultar()
        {
            Response<List<Noticia>> response = new Response<List<Noticia>>();

            Response<IEnumerable<Noticia>> responseNoticias = NoticiaQuerys.SelectNoticiasFiltroNoticias(FiltroNoticias);
            response.Status = responseNoticias.Status;
            if (response.Status.Exito == 1)
            {
                Noticias = responseNoticias.Data.ToList();
                Response<object> responseCargarListas = CargarListas();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = Noticias;
                    response.Info = responseNoticias.Info;
                }
            }

            return response;
        }

        private Response<object> CargarListas()
        {
            Response<object> response = new Response<object>();

            for (int i = 0; i < Noticias.Count; i++)
            {
                if (Noticias[i].Texto.Length > 150)
                {
                    Noticias[i].Texto = Noticias[i].Texto.Substring(0, 150) + "...";
                }

                Response<ArchivoNoticia> responseArchivoNoticia = ArchivoNoticiaQuerys.SelectArchivoNoticiaIdNoticiaPrincipal(Noticias[i].IdNoticia);
                response.Status = responseArchivoNoticia.Status;
                if (response.Status.Exito == 1)
                {
                    Noticias[i].ArchivosNoticia = new List<ArchivoNoticia>() { responseArchivoNoticia.Data };
                }
                else if (response.Status.Exito == 2)
                {
                    responseArchivoNoticia = ArchivoNoticiaQuerys.SelectArchivoNoticiaIdNoticiaFirst(Noticias[i].IdNoticia);
                    response.Status = responseArchivoNoticia.Status;
                    if (response.Status.Exito == 1)
                    {
                        Noticias[i].ArchivosNoticia = new List<ArchivoNoticia>() { responseArchivoNoticia.Data };
                    }
                    else if (response.Status.Exito == 2)
                    {
                        response.Status.Exito = 1;
                    }
                    else if (response.Status.Exito == 0)
                    {
                        i = Noticias.Count;
                    }
                }
                else if (response.Status.Exito == 0)
                {
                    i = Noticias.Count;
                }
            }

            return response;
        }
    }
}
