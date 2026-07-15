using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.LugarTuristicoLogic
{
    public class CrearLugarTuristicoLogic
    {
        private LugarTuristicoQuerys LugarTuristicoQuerys;

        private LugarTuristico LugarTuristico;

        public CrearLugarTuristicoLogic(CityAppContext cityAppContext, CrearLugarTuristico crearLugarTuristico)
        {
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContext);

            LugarTuristico = new LugarTuristico()
            {
                Nombre = crearLugarTuristico.Nombre,
                Descripcion = crearLugarTuristico.Descripcion,
                FechaFundacionConstruccionApertura = crearLugarTuristico.FechaFundacionConstruccionApertura,
                IdTipoLugarTuristico = crearLugarTuristico.IdTipoLugarTuristico,
                Telefono = crearLugarTuristico.Telefono,
                UrlWebFacebook = crearLugarTuristico.UrlWebFacebook,
                DireccionLugarTuristico = new DireccionLugarTuristico(),
            };
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            response = LugarTuristicoQuerys.SelectIdLugarTuristicoNombre(LugarTuristico.Nombre);
            if (response.Status.Exito == 2)
            {
                Response<object> responseInsertar = LugarTuristicoQuerys.InsertLugarTuristico(LugarTuristico);
                response.Status = responseInsertar.Status;
                if (response.Status.Exito == 1)
                {
                    response = LugarTuristicoQuerys.SelectIdLugarTuristicoNombre(LugarTuristico.Nombre);
                }
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 2;
                response.Status.Mensaje = "Ya se encuentra registrado";
            }
            

            return response;
        }
    }
}
