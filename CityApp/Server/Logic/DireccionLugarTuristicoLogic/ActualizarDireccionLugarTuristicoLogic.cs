using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.DireccionLugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.IdentityModel.Tokens;

namespace CityApp.Server.Logic.DireccionLugarTuristicoLogic
{
    public class ActualizarDireccionLugarTuristicoLogic
    {
        private DireccionLugarTuristicoQuerys DireccionLugarTuristicoQuerys;

        private ActualizarDireccionLugarTuristico ActualizarDireccionLugarTuristico;
        private DireccionLugarTuristico DireccionLugarTuristico;

        public ActualizarDireccionLugarTuristicoLogic(CityAppContext cityAppContext, ActualizarDireccionLugarTuristico actualizarDireccionLugarTuristico)
        {
            DireccionLugarTuristicoQuerys = new DireccionLugarTuristicoQuerys(cityAppContext);

            ActualizarDireccionLugarTuristico = actualizarDireccionLugarTuristico;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<DireccionLugarTuristico> responseDireccionLugarTuristico = DireccionLugarTuristicoQuerys.SelectDireccionLugaTuristicoIdLugarTuristico(ActualizarDireccionLugarTuristico.IdLugarTuristico);
            response.Status = responseDireccionLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                DireccionLugarTuristico = responseDireccionLugarTuristico.Data;
                response = ActualizarData();
                if (response.Status.Exito == 1)
                {
                    response = DireccionLugarTuristicoQuerys.UpdateDireccionLugarTuristico(DireccionLugarTuristico);
                }
            }

            return response;
        }

        private Response<object> ActualizarData()
        {
            Response<object> response = new Response<object>();

            try
            {
                DireccionLugarTuristico.Localidad = ActualizarDireccionLugarTuristico.Localidad;
                DireccionLugarTuristico.Colonia = ActualizarDireccionLugarTuristico.Colonia;
                DireccionLugarTuristico.Calle = ActualizarDireccionLugarTuristico.Calle;
                DireccionLugarTuristico.Numero = ActualizarDireccionLugarTuristico.Numero;
                DireccionLugarTuristico.CodigoPostal = ActualizarDireccionLugarTuristico.CodigoPostal;
                DireccionLugarTuristico.Latitud = ActualizarDireccionLugarTuristico.Latitud;
                DireccionLugarTuristico.Longitud = ActualizarDireccionLugarTuristico.Longitud;

                response.Status = CargarStatus.Ok();
            }
            catch (Exception ex)
            {
                response.Status = CargarStatus.Error(ex);
            }

            return response;
        }
    }
}
 