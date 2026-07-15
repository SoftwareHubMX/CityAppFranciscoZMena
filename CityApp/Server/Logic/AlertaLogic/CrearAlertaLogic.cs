using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys;
using CityApp.Server.Servicios.Geocoding;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaEntradaModel;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.GeolocalizacionModels;

namespace CityApp.Server.Logic.AlertaLogic
{
    public class CrearAlertaLogic
    {
        private AlertaQuerys AlertaQuerys;

        private ServicioGeocodingGoogle ServicioGeocodingGoogle = new ServicioGeocodingGoogle();

        private Alerta Alerta;
        public CrearAlertaLogic(CityAppContext cityAppContex, int idCuenta, CrearAlerta crearAlerta)
        {
            AlertaQuerys = new AlertaQuerys(cityAppContex);

            Alerta = new Alerta()
            {
                IdCuenta = idCuenta,
                DireccionAlerta = new DireccionAlerta()
                {
                    Longitud = crearAlerta.Longitud,
                    Latitud = crearAlerta.Latitud
                },
                IdEstatusAlerta = 1
            };
        }

        public Response<object> Crear()
        {
            Response<object> response = new Response<object>();

            Response<object> responseCordenadas = BuscarCordenadas();
            response.Status = responseCordenadas.Status;
            if (response.Status.Exito == 1)
            {
                Response<object> responseInsert = AlertaQuerys.InsertAlerta(Alerta);
                response = responseInsert;
            }

            return response;
        }

        private Response<object> BuscarCordenadas()
        {
            Response<object> response = new Response<object>();

            Response<DireccionGeocoding> responseDireccion = ServicioGeocodingGoogle.Geocoding(Alerta.DireccionAlerta.Latitud, Alerta.DireccionAlerta.Longitud);
            response.Status = responseDireccion.Status;
            if (response.Status.Exito == 1)
            {
                Alerta.DireccionAlerta.Localidad = responseDireccion.Data.Localidad.ToLower();
                Alerta.DireccionAlerta.Colonia = responseDireccion.Data.Colonia.ToLower();
                Alerta.DireccionAlerta.Calle = responseDireccion.Data.Calle.ToLower();
                Alerta.DireccionAlerta.Numero = responseDireccion.Data.Numero;
                Alerta.DireccionAlerta.CodigoPostal = responseDireccion.Data.CodigoPostal;
            }

            return response;
        }
    }
}
