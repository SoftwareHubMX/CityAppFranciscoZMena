using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AnuncioLogic
{
    public class ConsultarAnuncioAppLogic
    {
        private AnuncioQuerys AnuncioQuerys;
        private ArchivoAnuncioQuerys ArchivoAnuncioQuerys;
        private List<Anuncio> Anuncio;

        public ConsultarAnuncioAppLogic(CityAppContext cityAppContex)
        {
            AnuncioQuerys = new AnuncioQuerys(cityAppContex);
            ArchivoAnuncioQuerys = new ArchivoAnuncioQuerys(cityAppContex);
        }

        public Response<List<Anuncio>> Consultar()
        {
            Response<List<Anuncio>> response = new Response<List<Anuncio>>();

            Response<IEnumerable<Anuncio>> responseAnuncio = AnuncioQuerys.SelectAnuncios();
            response.Status = responseAnuncio.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Anuncio>();
                response.Data = responseAnuncio.Data.ToList();
                response.Info = new Info();
                response.Info = responseAnuncio.Info;
                for (int i = 0; i < response.Data.Count; i++)
                {
                    Response<IEnumerable<ArchivoAnuncio>> responseArchivos = new Response<IEnumerable<ArchivoAnuncio>>();
                    responseArchivos = ArchivoAnuncioQuerys.SelectArchivoAnuncioIdAnuncio(response.Data[i].IdAnuncio);
                    if (responseArchivos.Status.Exito == 1)
                    {
                        response.Data[i].ArchivosAnuncio = new List<ArchivoAnuncio>();
                        response.Data[i].ArchivosAnuncio = responseArchivos.Data.ToList();
                    }
                }
            }

            return response;
        }
    }
}
