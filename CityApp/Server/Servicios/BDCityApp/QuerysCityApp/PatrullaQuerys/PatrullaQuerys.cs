using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys
{
    public class PatrullaQuerys
    {
        private PatrullaInsert PatrullaInsert;
        private PatrullasSelect PatrullasSelect;
        private PatrullaSelect PatrullaSelect;
        private PatrullaDelete PatrullaDelete;
        private PatrullaUpdate PatrullaUpdate;

        public PatrullaQuerys(CityAppContext cityAppContext)
        {
            PatrullaInsert = new PatrullaInsert(cityAppContext);
            PatrullaSelect = new PatrullaSelect(cityAppContext);
            PatrullasSelect = new PatrullasSelect(cityAppContext);
            PatrullaDelete = new PatrullaDelete(cityAppContext);
        }

        //Insert
        public Response<object> InsertPartulla(Patrulla patrulla)
        {
            return PatrullaInsert.InsertPatrulla(patrulla);
        }

        //select
        public Response<Patrulla> SelectPatrulla(string placa, string numero)
        {
            return PatrullaSelect.SelectPatrulla(placa, numero);
        }
        public Response<Patrulla> SelectPatrullaIdPatrulla(int idPatrulla)
        {
            return PatrullaSelect.SelectPatrullaIdPatrulla(idPatrulla);
        }
        public Response<IEnumerable<Patrulla>> SelectPatrullaFiltroPatrulla(FiltroPatrullas filtroPatrullas)
        {
            return PatrullasSelect.SelectPatrullasFiltroPatrullas(filtroPatrullas);
        }

        //Update
        public Response<object> UpdatePartulla(Patrulla patrulla)
        {
            return PatrullaUpdate.UpdatePatrulla(patrulla);
        }

        //Delete
        public Response<object> DeletePatrulla(Patrulla patrulla)
        {
            return PatrullaDelete.DeletePatrulla(patrulla);
        }
    }
}
