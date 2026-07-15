using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Select
{
    public class ColoniasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Colonia> SelectCityApp = new SelectCityApp<Colonia>();
        private Paginado<Colonia> Paginado = new Paginado<Colonia>();

        public ColoniasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Colonia>> SelectColonias()
        {
            Response<IEnumerable<Colonia>> response = new Response<IEnumerable<Colonia>>();

            try
            {
                response.Data = CityAppContext.Colonias;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

    }
}
