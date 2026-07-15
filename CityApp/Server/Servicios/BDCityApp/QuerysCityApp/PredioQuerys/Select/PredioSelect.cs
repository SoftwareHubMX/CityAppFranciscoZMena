using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Select
{
    public class PredioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Predio> SelectCityApp = new SelectCityApp<Predio>();

        public PredioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Predio> SelectPredioIdPredio(int idPredio)
        {
            Response<Predio> response = new Response<Predio>();

            try
            {
                response.Data = CityAppContext.Predios.Where(
                    d => d.IdPredio == idPredio).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Predio> SelectPredioConsultaPredioUsuario(ConsultaPredioUsuario consultaPredioUsuario)
        {
            Response<Predio> response = new Response<Predio>();

            try
            {
                response.Data = response.Data = CityAppContext.Predios.Where(
                    d => d.Clave == consultaPredioUsuario.Clave 
                    && d.ClaveCatastral == consultaPredioUsuario.ClaveCatastral 
                    && d.Propietario == consultaPredioUsuario.Propietario).First();

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
