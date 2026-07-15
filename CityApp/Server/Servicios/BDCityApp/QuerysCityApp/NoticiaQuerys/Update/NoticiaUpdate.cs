using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Update
{
    public class NoticiaUpdate
    {
        private UpdateCityApp<Noticia> UpdateCityApp;

        public NoticiaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Noticia>(cityAppContext);
        }

        public Response<object> UpdateNoticia(Noticia noticia)
        {
            return UpdateCityApp.Save(noticia);
        }
    }
}
