using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Select
{
    public class PatrullaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Patrulla> SelectCityApp = new SelectCityApp<Patrulla>();

        private Paginado<Patrulla> Paginado = new Paginado<Patrulla>();

        public PatrullaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Patrulla> SelectPatrulla(string placa, string numero)
        {
            Response<Patrulla> response = new Response<Patrulla>();

            try
            {
                response.Data = CityAppContext.Patrullas.Where(d => 
                d.Placa == placa 
                && d.NumeroEconomico == numero).FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Patrulla> SelectPatrullaIdPatrulla(int IdPatrulla)
        {
            Response<Patrulla> response = new Response<Patrulla>();

            try
            {
                response.Data = CityAppContext.Patrullas.Where(d =>
                d.IdPatrulla == IdPatrulla).FirstOrDefault();

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
