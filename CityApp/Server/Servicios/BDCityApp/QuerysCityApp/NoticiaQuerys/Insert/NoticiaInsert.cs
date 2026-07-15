using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Insert
{
    public class NoticiaInsert
    {
        private InsertCityApp<Noticia> InsertCityApp;

        public NoticiaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Noticia>(cityAppContext);
        }

        public Response<object> InsertNoticia(Noticia noticia)
        {
            return InsertCityApp.Save(noticia);
        }
    }
}
