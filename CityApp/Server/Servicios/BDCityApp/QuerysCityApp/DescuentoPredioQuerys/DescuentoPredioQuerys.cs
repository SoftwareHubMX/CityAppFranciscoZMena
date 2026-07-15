using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys
{
    public class DescuentoPredioQuerys
    {
        private DescuentoPredioInsert DescuentoPredioInsert;
        private DescuentoPredioSelect DescuentoPredioSelect;
        private DescuentosPrediosSelect DescuentosPrediosSelect;
        private DescuentoPredioUpdate DescuentoPredioUpdate;
        private DescuentoPredioDelete DescuentoPredioDelete;

        public DescuentoPredioQuerys(CityAppContext cityAppContext)
        {
            DescuentoPredioInsert = new DescuentoPredioInsert(cityAppContext);
            DescuentoPredioSelect = new DescuentoPredioSelect(cityAppContext);
            DescuentosPrediosSelect = new DescuentosPrediosSelect(cityAppContext);
            DescuentoPredioUpdate = new DescuentoPredioUpdate(cityAppContext);
            DescuentoPredioDelete = new DescuentoPredioDelete(cityAppContext);
        }

        //Insert
        public Response<object> InsertDescuentoPredio(DescuentoPredio descuentoPredio)
        {
            return DescuentoPredioInsert.InsertDescuentoPredio(descuentoPredio);
        }

        //Select
        public Response<DescuentoPredio> SelectDescuentoPredioIdDescuentoPredio(int idDescuentoPresio)
        {
            return DescuentoPredioSelect.SelectDescuentoPredioIdDescuentoPredio(idDescuentoPresio);
        }
        public Response<IEnumerable<DescuentoPredio>> SelectDescuentosPredios(FiltroDescuentoPredios filtroDescuentosPredios)
        {
            return DescuentosPrediosSelect.SelectDescuentosPredios(filtroDescuentosPredios);
        }
        public Response<IEnumerable<DescuentoPredio>> SelectDescuentosPrediosHoy()
        {
            return DescuentosPrediosSelect.SelectDescuentosPrediosHoy();
        }

        //Update
        public Response<object> UpdateDescuentoPredio(DescuentoPredio descuentoPredio)
        {
            return DescuentoPredioUpdate.UpdateDescuentoPredio(descuentoPredio);
        }

        //Delete
        public Response<object> DeleteDescuentoPredio(DescuentoPredio descuentoPredio)
        {
            return DescuentoPredioDelete.DeleteDescuentoPredio(descuentoPredio);
        }
    }
}
