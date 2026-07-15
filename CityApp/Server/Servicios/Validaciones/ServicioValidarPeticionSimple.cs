using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Validaciones
{
    public class ServicioValidarPeticionSimple
    {
        private Peticion<object> Peticion = new Peticion<object>();

        public Response<object> Validar(string token)
        {
            Response<object> response = new Response<object>();

            if (Peticion.Token == token)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
