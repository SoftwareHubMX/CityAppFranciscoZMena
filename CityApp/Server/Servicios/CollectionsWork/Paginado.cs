using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.CollectionsWork
{
    public class Paginado<T>
    {

        public Response<IEnumerable<T>> Paginar(IEnumerable<T> coleccion, int maximoElementos, int pagina)
        {
            Response<IEnumerable<T>> response = new Response<IEnumerable<T>>();

            try
            {
                int totalElemntos = coleccion.Count();

                if (totalElemntos > 0)
                {
                    response.Info.TotalData = (
                            (totalElemntos % maximoElementos) == 0) ?
                            (totalElemntos / maximoElementos) :
                            (totalElemntos / maximoElementos) + 1;

                    response.Info.InfoData = "Noticias totales : " + totalElemntos + " - "
                        + "Pagina : " + pagina + " - "
                        + "De : " + response.Info.TotalData;

                    response.Data = coleccion.Skip((pagina - 1) * maximoElementos).Take(maximoElementos);

                    response.Status.Exito = 1;
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "La coleccion esta bacía";
                }
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al paginar";
            }

            return response;
        }
    }
}
