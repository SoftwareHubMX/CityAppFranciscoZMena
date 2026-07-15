using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AnuncioLogic
{
    public class ConsultarAnuncioLogic
    {
        private AnuncioQuerys AnuncioQuerys;
        private ArchivoAnuncioQuerys ArchivoAnuncioQuerys;

        private int IdAnuncio = 0;
        private Anuncio anuncio = new Anuncio();

        public ConsultarAnuncioLogic(CityAppContext cityAppContetx, int idAnuncio)
        {
            AnuncioQuerys = new AnuncioQuerys(cityAppContetx);
            ArchivoAnuncioQuerys = new ArchivoAnuncioQuerys(cityAppContetx);

            IdAnuncio = idAnuncio;
        }

        public Response<Anuncio> Consultar()
        {
            Response<Anuncio> response = new Response<Anuncio>();

            response = AnuncioQuerys.SelectAnuncioIdAnuncio(IdAnuncio);
            if (response.Status.Exito == 1)
            {
                anuncio = response.Data;
                Response<object> responseCargarListas = CargarArchivos();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = anuncio;
                }
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoAnuncio>> responseArchivoAnuncio = ArchivoAnuncioQuerys.SelectArchivoAnuncioIdAnuncio(IdAnuncio);
            response.Status = responseArchivoAnuncio.Status;
            if (response.Status.Exito == 1)
            {
                anuncio.ArchivosAnuncio = new List<ArchivoAnuncio>();
                anuncio.ArchivosAnuncio = responseArchivoAnuncio.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
