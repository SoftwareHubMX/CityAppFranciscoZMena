using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Select
{
    public class NormatividadSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Normatividad> SelectCityApp = new SelectCityApp<Normatividad>();

        private Paginado<Normatividad> Paginado = new Paginado<Normatividad>();

        public NormatividadSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Normatividad> SelectNormatividad(int idNormatividad)
        {
            Response<Normatividad> response = new Response<Normatividad>();

            try
            {
                response.Data = CityAppContext.Normatividades.Where(d =>
                d.IdNormatividad == idNormatividad).FirstOrDefault();

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
