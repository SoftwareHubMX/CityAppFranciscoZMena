using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys.Update
{
    public class UsuarioUpdate
    {
        private UpdateCityApp<Usuario> UpdateCityApp;

        public UsuarioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Usuario>(cityAppContext);
        }

        public Response<object> UpdateUsuario(Usuario usuario)
        {
            return UpdateCityApp.Save(usuario);
        }
    }
}
