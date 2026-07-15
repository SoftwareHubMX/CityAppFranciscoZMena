

using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.ConexionCityApp
{
    public class SelectCityApp<T>
    {
        public Status ValidarObjeto(T data)
        {
            Status status;

            if (data != null)
            {
                status = new Status()
                {
                    Exito = 1,
                    Mensaje = "OK",
                };
            }
            else
            {
                status = new Status()
                {
                    Exito = 2,
                    Mensaje = "No se encontraron datos",
                };
            }

            return status;
        }

        public Status ValidarLista(IEnumerable<T> data)
        {
            Status status;

            if (data != null)
            {
                if (data.Count() > 0)
                {
                    status = new Status()
                    {
                        Exito = 1,
                        Mensaje = "OK",
                    };
                }
                else
                {
                    status = new Status()
                    {
                        Exito = 2,
                        Mensaje = "No se encontraron datos",
                    };
                }
            }
            else
            {
                status = new Status()
                {
                    Exito = 2,
                    Mensaje = "No se encontraron datos",
                };
            }

            return status;
        }

        public Status Error(Exception ex)
        {
            Status status = new Status();

            status.Exception = ex.Message;
            if (status.Exception == "Sequence contains no elements")
            {
                status.Exito = 2;
                status.Mensaje = "No se encontraron datos";
            }
            else
            {
                status.Mensaje = "Ocurrio un error";
            }

            return status;
        }
    }
}
