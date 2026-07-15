using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class ConsultarRutaRecoleccionLogic
    {
        private RutaRecoleccionQuerys RutaRecoleccionQuerys;
        private DiaRutaQuerys DiaRutaQuerys;
        private ColoniaQuerys ColoniaQuerys;
        private ColoniaRutaRecoleccionQuerys ColoniaRutaRecoleccionQuerys;


        private int IdRutaRecoleccion;
        private RutaRecoleccion RutaRecoleccion;

        public ConsultarRutaRecoleccionLogic(CityAppContext cityAppContetx, int idRutaRecoleccion)
        {
            RutaRecoleccionQuerys = new RutaRecoleccionQuerys(cityAppContetx);
            DiaRutaQuerys = new DiaRutaQuerys(cityAppContetx);
            ColoniaQuerys = new ColoniaQuerys(cityAppContetx);
            ColoniaRutaRecoleccionQuerys = new ColoniaRutaRecoleccionQuerys(cityAppContetx);
            IdRutaRecoleccion = idRutaRecoleccion;
        }

        public Response<RutaRecoleccion> Consultar()
        {
            Response<RutaRecoleccion> responseRecolecion = new Response<RutaRecoleccion>();
            responseRecolecion = RutaRecoleccionQuerys.SelectRutaRecoleccionIdRutaRecoleccion(IdRutaRecoleccion);
            if(responseRecolecion.Status.Exito == 1)
            {
                Response<IEnumerable<DiaRuta>> responseDias = new Response<IEnumerable<DiaRuta>>();
                responseDias = DiaRutaQuerys.SelectDiasRuta(responseRecolecion.Data.IdRutaRecoleccion);
                if (responseDias.Status.Exito == 1)
                {
                    responseRecolecion.Data.DiasRuta = new List<DiaRuta>();
                    responseRecolecion.Data.DiasRuta = responseDias.Data.ToList(); 
                    for (int j = 0; j < responseRecolecion.Data.DiasRuta.Count; j++)
                    {
                        responseRecolecion.Data.DiasRuta[j].RutaRecoleccion = null;
                    }
                }
                Response<IEnumerable<ColoniaRutaRecoleccion>> responseColoniaRuta = new Response<IEnumerable<ColoniaRutaRecoleccion>>();
                responseColoniaRuta = ColoniaRutaRecoleccionQuerys.SelectColoniasRutaRecoleccion(responseRecolecion.Data.IdRutaRecoleccion);
                if (responseColoniaRuta.Status.Exito == 1)
                {
                    responseRecolecion.Data.ColoniaRutaRecolecciones = new List<ColoniaRutaRecoleccion>();
                    responseRecolecion.Data.ColoniaRutaRecolecciones = responseColoniaRuta.Data.ToList();
                    for (int j = 0; j < responseRecolecion.Data.ColoniaRutaRecolecciones.Count; j++)
                    {
                        responseRecolecion.Data.ColoniaRutaRecolecciones[j].RutaRecoleccion = null;
                        Response<Colonia> responseColonia = new Response<Colonia>();
                        responseColonia = ColoniaQuerys.SelectColoniaIdColonia(responseRecolecion.Data.ColoniaRutaRecolecciones[j].IdColonia);
                        if (responseColonia.Status.Exito == 1)
                        {
                            responseRecolecion.Data.ColoniaRutaRecolecciones[j].Colonia = new Colonia();
                            responseRecolecion.Data.ColoniaRutaRecolecciones[j].Colonia = responseColonia.Data;
                        }
                    }
                }           
            }
            return responseRecolecion;
        }
    }
}
