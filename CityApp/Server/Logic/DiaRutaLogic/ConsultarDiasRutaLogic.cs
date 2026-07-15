using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DiaRutaLogic
{
    public class ConsultarDiasRutaLogic
    {
        private DiaRutaQuerys DiaRutaQuerys;
        private List<DiaRuta> DiaRuta;
        private int IdRutaRecoleccion = 0;


        public ConsultarDiasRutaLogic(CityAppContext cityAppContex, int idRutaRecoleccion)
        {
            DiaRutaQuerys = new DiaRutaQuerys(cityAppContex);
            IdRutaRecoleccion = idRutaRecoleccion;
        }

        public Response<List<DiaRuta>> Consultar()
        {
            Response<List<DiaRuta>> response = new Response<List<DiaRuta>>();

            Response<IEnumerable<DiaRuta>> responseDiaRuta = DiaRutaQuerys.SelectDiasRuta(IdRutaRecoleccion);
            response.Status = responseDiaRuta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<DiaRuta>();
                response.Data = responseDiaRuta.Data.ToList();
            }

            return response;
        }
    }
}
