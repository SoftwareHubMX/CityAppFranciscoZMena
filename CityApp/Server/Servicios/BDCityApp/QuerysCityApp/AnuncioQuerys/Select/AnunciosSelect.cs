using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Select
{
    public class AnunciosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Anuncio> SelectCityApp = new SelectCityApp<Anuncio>();

        private Paginado<Anuncio> Paginado = new Paginado<Anuncio>();

        public AnunciosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Anuncio>> SelectAnuncios()
        {
            Response<IEnumerable<Anuncio>> response = new Response<IEnumerable<Anuncio>>();

            try
            {
                response.Data = CityAppContext.Anuncios;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Anuncio>> SelectAnuncioFirltoAnuncio(FiltroAnuncio filtroAnuncio)
        {
            Response<IEnumerable<Anuncio>> response = new Response<IEnumerable<Anuncio>>();

            try
            {
                response.Data = CityAppContext.Anuncios;
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroAnuncio.MaximoElementos, filtroAnuncio.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
