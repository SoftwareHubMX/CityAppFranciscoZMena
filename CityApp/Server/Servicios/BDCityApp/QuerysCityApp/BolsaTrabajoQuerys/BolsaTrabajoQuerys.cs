using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys
{
    public class BolsaTrabajoQuerys
    {
        private BolsaTrabajoInsert BolsaTrabajoInsert;
        private BolsaTrabajoDelete BolsaTrabajoDelete;
        private BolsaTrabajoUpdate BolsaTrabajoUpdate;
        private BolsaTrabajoSelect BolsaTrabajoSelect;
        private BolsasTrabajosSelect BolsasTrabajosSelect;
        private TotalBolsasTrabajosSelect TotalBolsasTrabajosSelect;    

        public BolsaTrabajoQuerys(CityAppContext cityAppContext)
        {
            BolsaTrabajoInsert = new BolsaTrabajoInsert(cityAppContext);
            BolsaTrabajoDelete = new BolsaTrabajoDelete(cityAppContext);
            BolsaTrabajoUpdate = new BolsaTrabajoUpdate(cityAppContext);
            BolsaTrabajoSelect = new BolsaTrabajoSelect(cityAppContext);
            BolsasTrabajosSelect = new BolsasTrabajosSelect(cityAppContext);
            TotalBolsasTrabajosSelect = new TotalBolsasTrabajosSelect(cityAppContext);

        }

        //Insert

        public Response<object> InsertBolsaTrabajo(BolsaTrabajo bolsaTrabajo)
        {
            return BolsaTrabajoInsert.InsertBolsaTrabajo(bolsaTrabajo);
        }

        //Delete 
        public Response<object> DeleteBolsaTrabajo(BolsaTrabajo bolsaTrabajo)
        {
            return BolsaTrabajoDelete.DeleteBolsaTrabajo(bolsaTrabajo);
        }

        //Update
        public Response<object> UpdateBolsaTrabajo(BolsaTrabajo bolsaTrabajo)
        {
            return BolsaTrabajoUpdate.UpdateBolsaTrabajo(bolsaTrabajo);
        }

        //Select 
        public Response<BolsaTrabajo> SelectBolsaTrabajoIdBolsaTrabajo(int idBolsaTrabajo)
        {
            return BolsaTrabajoSelect.SelectBolsaTrabajoIdBolsaTrabajo(idBolsaTrabajo);
        }

        public Response<IEnumerable<BolsaTrabajo>> SelectTotalBolsasTrabajoFechaEstatus(DateTime fechaPublicacion, bool estatus)
        {
            return TotalBolsasTrabajosSelect.SelectTotalBolsasTrabajoFechaEstatus(fechaPublicacion, estatus);
        }
        public Response<IEnumerable<BolsaTrabajo>> SelectBolsasTrabajos()
        {
            return BolsasTrabajosSelect.SelectBolsasTrabajos();
        }
        public Response<IEnumerable<BolsaTrabajo>> SelectBolsaTrabajoFiltroBolsaTrabajo(FiltroBolsaTrabajo filtroBolsaTrabajo)
        {
            return BolsasTrabajosSelect.SelectBolsaTrabajoFirltoBolsaTrabajo(filtroBolsaTrabajo);
        }


    }
}
