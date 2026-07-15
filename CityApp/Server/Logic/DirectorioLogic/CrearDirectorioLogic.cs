using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DirectorioLogic
{
    public class CrearDirectorioLogic
    {
        private DirectorioQuerys DirectorioQuerys;

        private Directorio Directorio;

        public CrearDirectorioLogic(CityAppContext cityAppContext, Directorio directorio)
        {
            DirectorioQuerys = new DirectorioQuerys(cityAppContext);

            Directorio = directorio;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseSlider = DirectorioQuerys.InsertDirectorio(Directorio);
            response.Status = responseSlider.Status;
            if (response.Status.Exito == 1)
            {
                response = DirectorioQuerys.SelectIdDirectorioNombre(Directorio.NombreDirecctorio);
            }

            return response;
        }
    }
}
