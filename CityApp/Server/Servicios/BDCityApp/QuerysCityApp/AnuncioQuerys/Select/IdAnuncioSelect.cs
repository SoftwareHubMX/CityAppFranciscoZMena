using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Select
{
    public class IdAnuncioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdAnuncioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectIdAnuncioTitulo(string texto)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.Anuncios
                                 orderby data.IdAnuncio
                                 where data.Titulo == texto
                                 select data.IdAnuncio).LastOrDefault();

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
