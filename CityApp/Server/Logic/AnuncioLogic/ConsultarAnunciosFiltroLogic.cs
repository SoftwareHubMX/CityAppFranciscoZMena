using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AnuncioLogic
{
    public class ConsultarAnunciosFiltroLogic
    {
        private AnuncioQuerys AnuncioQuerys;
        private ArchivoAnuncioQuerys ArchivoAnuncioQuerys;
        private List<Anuncio> Anuncio = new List<Anuncio>();
        private FiltroAnuncio FiltroAnuncio = new FiltroAnuncio();


        public ConsultarAnunciosFiltroLogic(CityAppContext cityAppContex, FiltroAnuncio filtroAnuncio)
        {
            AnuncioQuerys = new AnuncioQuerys(cityAppContex);
            ArchivoAnuncioQuerys = new ArchivoAnuncioQuerys(cityAppContex);
            FiltroAnuncio = filtroAnuncio;
        }

        public Response<List<Anuncio>> Consultar()
        {
            Response<List<Anuncio>> response = new Response<List<Anuncio>>();

            Response<IEnumerable<Anuncio>> responseAnuncio = AnuncioQuerys.SelectAnuncioFirltoAnuncio(FiltroAnuncio);
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
