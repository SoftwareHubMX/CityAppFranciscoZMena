using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Delete
{
    public class NoticiaDelete
    {
        private DeleteCityApp<Noticia> DeleteCityApp;

        public NoticiaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Noticia>(cityAppContext);
        }

        public Response<object> DeleteNoticia(Noticia Noticia)
        {
            return DeleteCityApp.Save(Noticia);
        }
    }
}
