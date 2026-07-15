using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Select
{
    public class ColoniaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Colonia> SelectCityApp = new SelectCityApp<Colonia>();

        public ColoniaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Colonia> SelectColoniaIdColonia(int idColonia)
        {
            Response<Colonia> response = new Response<Colonia>();

            try
            {
                response.Data = CityAppContext.Colonias.Where(d => d.IdColonia == idColonia).First();

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
