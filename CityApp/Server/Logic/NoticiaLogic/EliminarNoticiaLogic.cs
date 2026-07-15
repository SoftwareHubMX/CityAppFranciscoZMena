using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NoticiaLogic
{
    public class EliminarNoticiaLogic
    {
        private NoticiaQuerys NoticiaQuerys;
        private ArchivoNoticiaQuerys ArchivoNoticiaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private Noticia Noticia;

        public EliminarNoticiaLogic(CityAppContext cityAppContext, int idNoticia)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContext);
            ArchivoNoticiaQuerys = new ArchivoNoticiaQuerys(cityAppContext);

            Noticia = new Noticia()
            {
                IdNoticia = idNoticia,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Noticia> responseNotica = NoticiaQuerys.SelectNoticiaIdNoticia(Noticia.IdNoticia);
            response.Status = responseNotica.Status;
            if (response.Status.Exito == 1)
            {
                Noticia = responseNotica.Data;
                response = EliminarListaArchivos();
                if (response.Status.Exito == 1)
                {
                    response = NoticiaQuerys.DeleteNoticia(responseNotica.Data);
                }
            }

            return response;
        }

        private Response<object> EliminarListaArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoNoticia>> responseArchivosNoticia = ArchivoNoticiaQuerys.SelectArchivosNoticiaIdNoticia(Noticia.IdNoticia);
            response.Status = responseArchivosNoticia.Status;
            if (response.Status.Exito == 1)
            {
                Noticia.ArchivosNoticia = responseArchivosNoticia.Data.ToList();
                response = EliminarFicheros();
                if (response.Status.Exito == 1)
                {
                    response = ArchivoNoticiaQuerys.DeleteArchivosNoticia(responseArchivosNoticia.Data);
                }
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> EliminarFicheros()
        {
            Response<object> response = new Response<object>();

            foreach(var archivo in Noticia.ArchivosNoticia)
            {
                string ruta = Rutas.RutaMultimediaNoticias + Noticia.IdNoticia + "\\" + archivo.Ruta;
                response = ServicioFicheros.ArchivoEliminar(ruta);
                if (response.Status.Exito != 1)
                {
                    break;
                }
            }

            return response;
        }
    }
}
