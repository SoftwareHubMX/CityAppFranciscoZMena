using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class ConsultarFiltroRutasRecoleccionesLogic
    {
        private DiaRutaQuerys DiaRutaQuerys;
        private RutaRecoleccionQuerys RutaRecoleccionQuerys;
        private ColoniaRutaRecoleccionQuerys ColoniaRutaRecoleccionQuerys;
        private FiltroRutaRecoleccion FiltroRutaRecoleccion;
        private ColoniaQuerys ColoniaQuerys;


        public ConsultarFiltroRutasRecoleccionesLogic(CityAppContext cityAppContex, FiltroRutaRecoleccion filtroRutaRecoleccion)
        {
            RutaRecoleccionQuerys = new RutaRecoleccionQuerys(cityAppContex);
            ColoniaRutaRecoleccionQuerys = new ColoniaRutaRecoleccionQuerys(cityAppContex);
            ColoniaQuerys = new ColoniaQuerys(cityAppContex);
            FiltroRutaRecoleccion = filtroRutaRecoleccion;
            DiaRutaQuerys = new DiaRutaQuerys(cityAppContex);

        }

        public Response<List<RutaRecoleccion>> Consultar()
        {
            Response<List<RutaRecoleccion>> response = new Response<List<RutaRecoleccion>>();

            Response<IEnumerable<RutaRecoleccion>> responseRutaRecoleccion = RutaRecoleccionQuerys.SelectRutaRecoleccionFirltoRutaRecoleccion(FiltroRutaRecoleccion);
            response.Status = responseRutaRecoleccion.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<RutaRecoleccion>();
                response.Data = responseRutaRecoleccion.Data.ToList();
                response.Info = new Info();
                response.Info = responseRutaRecoleccion.Info;
                for(int i= 0; i < response.Data.Count; i++)
                {
                    Response<IEnumerable<DiaRuta>> responseDias = new Response<IEnumerable<DiaRuta>>();
                    responseDias = DiaRutaQuerys.SelectDiasRuta(response.Data[i].IdRutaRecoleccion);
                    if(responseDias.Status.Exito == 1)
                    {
                        response.Data[i].DiasRuta = new List<DiaRuta>();
                        response.Data[i].DiasRuta = responseDias.Data.ToList();
                        for(int j= 0; j < response.Data[i].DiasRuta.Count; j++)
                        {
                            response.Data[i].DiasRuta[j].RutaRecoleccion = null;
                        }
                    }
                    Response<IEnumerable<ColoniaRutaRecoleccion>> responseColoniaRuta = new Response<IEnumerable<ColoniaRutaRecoleccion>>();
                    responseColoniaRuta = ColoniaRutaRecoleccionQuerys.SelectColoniasRutaRecoleccion(response.Data[i].IdRutaRecoleccion);
                    if(responseColoniaRuta.Status.Exito == 1)
                    {
                        response.Data[i].ColoniaRutaRecolecciones = new List<ColoniaRutaRecoleccion>();
                        response.Data[i].ColoniaRutaRecolecciones = responseColoniaRuta.Data.ToList();
                        for(int j= 0; j < response.Data[i].ColoniaRutaRecolecciones.Count; j++)
                        {
                            response.Data[i].ColoniaRutaRecolecciones[j].RutaRecoleccion = null;
                            Response<Colonia> responseColonia = new Response<Colonia>();
                            responseColonia = ColoniaQuerys.SelectColoniaIdColonia(response.Data[i].ColoniaRutaRecolecciones[j].IdColonia);
                            if(responseColonia.Status.Exito == 1)
                            {
                                response.Data[i].ColoniaRutaRecolecciones[j].Colonia = new Colonia();
                                response.Data[i].ColoniaRutaRecolecciones[j].Colonia = responseColonia.Data;
                                response.Data[i].ColoniaRutaRecolecciones[j].RutaRecoleccion = null;
                            }
                        }
                    }
                    
                }
            }

            return response;
        }
    }
}
