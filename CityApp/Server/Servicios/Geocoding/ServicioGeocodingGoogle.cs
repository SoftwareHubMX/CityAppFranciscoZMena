using CityApp.Server.Servicios.PeticionesAPI;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.GeolocalizacionModels;

namespace CityApp.Server.Servicios.Geocoding
{
    public class ServicioGeocodingGoogle
    {
        private GET<ResponseGeocode> GET = new GET<ResponseGeocode>();

        public Response<DireccionGeocoding> Geocoding(double lat, double lng)
        {
            Response<DireccionGeocoding> response = new Response<DireccionGeocoding>();

            string url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" +
                lat + "," + lng +
            "&key=AIzaSyB4xyl7H92TyGEDZTmwz6cxji-nNW5iPgQ";
            //"&key=AIzaSyAX41lPpgS-Q1Fwbwc7Yz6SIS7LmLIkAlU";
            //"&key=AIzaSyCP48uDUoZITdu9NX64GVHu8oURdoLhlPs";


            Response<ResponseGeocode> responseGeoCode = GET.GetData(url);
            response.Status = responseGeoCode.Status;
            if (response.Status.Exito == 1)
            {
                if (responseGeoCode.Data.results.Count > 0)
                {
                    if (responseGeoCode.Data.results[0].address_components.Count > 0)
                    {
                        response.Data = new DireccionGeocoding();
                        foreach (var component in responseGeoCode.Data.results[0].address_components)
                        {
                            foreach (var type in component.types)
                            {
                                if (type == "street_number")
                                {
                                    response.Data.Numero = component.long_name;
                                    break;
                                }
                                else if (type == "route")
                                {
                                    response.Data.Calle = component.long_name;
                                    break;
                                }
                                else if (type == "sublocality" || type == "sublocality_level_1")
                                {
                                    response.Data.Colonia = component.long_name;
                                    break;
                                }
                                else if (type == "postal_code")
                                {
                                    response.Data.CodigoPostal = component.long_name;
                                    break;
                                }
                                else if (type == "locality")
                                {
                                    response.Data.Localidad = component.long_name;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        response.Status.Exito = 2;
                        response.Status.Mensaje = "No se pudieron ubicar las cordenadas";
                    }
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "No se pudieron ubicar las cordenadas";
                }
            }

            return response;
        }
    }
}
