using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;
using SpreadsheetLight;

namespace CityApp.Server.Logic.PredioLogic
{
    public class ActualizarPrediosExcelLogic
    {
        private PredioQuerys PredioQuerys;

        private string NombreExcel = "";

        public ActualizarPrediosExcelLogic(CityAppContext cityAppContext, string excel)
        {
            PredioQuerys = new PredioQuerys(cityAppContext);

            NombreExcel = excel;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaHistoricosPredios + NombreExcel;
            response = ActualizarPredios(ruta);

            return response;
        }

        private Response<object> ActualizarPredios(string ruta)
        {
            Response<object> response = new Response<object>();

            try
            {
                if (File.Exists(ruta))
                {
                    SLDocument excel = new SLDocument(ruta);
                    int fila = 2;

                    do
                    {
                        Predio predio = new Predio()
                        {
                            IdPredio = int.Parse(excel.GetCellValueAsString(fila, 1)),
                            Clave = excel.GetCellValueAsString(fila, 2),
                            ClaveCatastral = excel.GetCellValueAsString(fila, 3),
                            Resago = int.Parse(excel.GetCellValueAsString(fila, 4)),
                            Direccion = excel.GetCellValueAsString(fila, 5),
                            Poblacion = excel.GetCellValueAsString(fila, 6),
                            Ciudad = excel.GetCellValueAsString(fila, 7),
                            Estado = excel.GetCellValueAsString(fila, 8),
                            CodigoPostal = excel.GetCellValueAsString(fila, 9),
                            Propietario = excel.GetCellValueAsString(fila, 10),
                            Total = excel.GetCellValueAsDouble(fila, 12),
                        };
                        string strFecha = excel.GetCellValueAsString(fila, 11);
                        string[] arrayFecha = strFecha.Split('/');
                        if (arrayFecha.Length < 3)
                        {
                            predio.FechaUltimoPago = excel.GetCellValueAsDateTime(fila, 11);
                        }
                        else
                        {
                            predio.FechaUltimoPago = new DateTime(int.Parse(arrayFecha[2]), int.Parse(arrayFecha[1]), int.Parse(arrayFecha[0]));
                        }

                        response = ActualizarPredio(predio);

                        fila++;
                    }
                    while (!string.IsNullOrEmpty(excel.GetCellValueAsString(fila, 1)) && response.Status.Exito != 0);
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "No se encuentra el fichero";
                }
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al leer el excel: " + ruta;
            }

            return response;
        }

        private Response<object> ActualizarPredio(Predio predio)
        {
            Response<object> response = new Response<object>();
            response = PredioQuerys.UpdatePredio(predio);
            if(response.Status.Exito == 1)
            {
                return response;
            }
            else
            {
                predio.IdPredio = 0;
                response = PredioQuerys.InsertPredio(predio);
            }

            return response;
        }
    }
}
