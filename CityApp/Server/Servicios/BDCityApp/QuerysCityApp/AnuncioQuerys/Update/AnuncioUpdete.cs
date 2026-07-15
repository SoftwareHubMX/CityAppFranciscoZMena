using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Update
{
    public class AnuncioUpdete
    {
        private UpdateCityApp<Anuncio> UpdateCityApp;

        public AnuncioUpdete(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Anuncio>(cityAppContext);
        }
        public Response<object> UpdateAnuncio(Anuncio anuncio)
        {
            return UpdateCityApp.Save(anuncio);
        }
    }
}
