using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Select
{
    public class AnuncioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Anuncio> SelectCityApp = new SelectCityApp<Anuncio>();

        public AnuncioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<Anuncio> SelectAnuncioIdAnuncio(int idAnuncio)
        {
            Response<Anuncio> response = new Response<Anuncio>();

            try
            {
                response.Data = CityAppContext.Anuncios.Where(d => d.IdAnuncio == idAnuncio).FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
