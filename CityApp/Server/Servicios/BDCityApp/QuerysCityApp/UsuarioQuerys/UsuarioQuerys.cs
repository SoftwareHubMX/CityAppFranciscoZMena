using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys
{
    public class UsuarioQuerys
    {
        private UsuarioInsert UsuarioInsert;
        private UsuarioSelect UsuarioSelect;
        private UsuarioUpdate UsuarioUpdate;

        public UsuarioQuerys(CityAppContext cityAppContex)
        {
            UsuarioInsert = new UsuarioInsert(cityAppContex);
            UsuarioSelect = new UsuarioSelect(cityAppContex);
            UsuarioUpdate = new UsuarioUpdate(cityAppContex);
        }

        //insert
        public Response<object> InsertUsuario(Usuario usuario)
        {
            return UsuarioInsert.InsertUsuario(usuario);
        }

        //select
        public Response<Usuario> SelectUsuarioIdCuenta(int idCuenta)
        {
            return UsuarioSelect.SelectUsuarioIdCuenta(idCuenta);
        }
        public Response<Usuario> SelectUsuarioId(int idUsuario)
        {
            return UsuarioSelect.SelectUsuarioId(idUsuario);
        }

        //update
        public Response<object> UpdateUsuario(Usuario usuario)
        {
            return UsuarioUpdate.UpdateUsuario(usuario);
        }
    }
}
