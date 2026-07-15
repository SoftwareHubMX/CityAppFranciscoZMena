using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys.Insert
{
    public class UsuarioInsert
    {
        private InsertCityApp<Usuario> InsertCityApp;

        public UsuarioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Usuario>(cityAppContext);
        }

        public Response<object> InsertUsuario(Usuario usuario)
        {
            return InsertCityApp.Save(usuario);
        }
    }
}
