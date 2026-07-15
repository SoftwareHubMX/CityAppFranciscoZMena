using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DirectorioLogic
{
    public class EditarDirectorioLogic
    {
        private DirectorioQuerys DirectorioQuerys;

        private Directorio Directorio;

        public EditarDirectorioLogic(CityAppContext cityAppContext, Directorio directorio)
        {
            DirectorioQuerys = new DirectorioQuerys(cityAppContext);

            Directorio = directorio;
        }

        public Response<object> Editar()
        {
            Response<object> response = new Response<object>();

            response = DirectorioQuerys.UpdateDirectorio(Directorio);

            return response;
        }
    }
}
