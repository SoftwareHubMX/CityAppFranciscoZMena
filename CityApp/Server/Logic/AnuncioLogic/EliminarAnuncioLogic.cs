using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AnuncioLogic
{
    public class EliminarAnuncioLogic
    {
        private AnuncioQuerys AnuncioQuerys;
        private ArchivoAnuncioQuerys ArchivoAnuncioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private Anuncio Anuncio;

        public EliminarAnuncioLogic(CityAppContext cityAppContext, int idAnuncio)
        {
            AnuncioQuerys = new AnuncioQuerys(cityAppContext);
            ArchivoAnuncioQuerys = new ArchivoAnuncioQuerys(cityAppContext);

            Anuncio = new Anuncio()
            {
                IdAnuncio = idAnuncio,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Anuncio> responseArchivosAnuncio = AnuncioQuerys.SelectAnuncioIdAnuncio(Anuncio.IdAnuncio);
            response.Status = responseArchivosAnuncio.Status;
            if (response.Status.Exito == 1)
            {
                Anuncio = responseArchivosAnuncio.Data;
                response = EliminarListaArchivos();
                if (response.Status.Exito == 1)
                {
                    response = AnuncioQuerys.DeleteAnuncio(responseArchivosAnuncio.Data);
                }
            }

            return response;
        }

        private Response<object> EliminarListaArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoAnuncio>> responseArchivosAnuncio = ArchivoAnuncioQuerys.SelectArchivoAnuncioIdAnuncio(Anuncio.IdAnuncio);
            response.Status = responseArchivosAnuncio.Status;
            if (response.Status.Exito == 1)
            {
                Anuncio.ArchivosAnuncio = responseArchivosAnuncio.Data.ToList();
                response = EliminarFicheros();
                if (response.Status.Exito == 1)
                {
                    response = ArchivoAnuncioQuerys.DeleteArchivosAnuncio(responseArchivosAnuncio.Data);
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

            foreach (var archivo in Anuncio.ArchivosAnuncio)
            {
                string ruta = Rutas.RutaMultimediaArchivoAnuncio + Anuncio.IdAnuncio + "\\" + archivo.Ruta;
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
