using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.ControllersModels.PredioSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PredioLogic
{
    public class ConsultarPredioUsuarioLogic
    {
        private PredioQuerys PredioQuerys;

        private ConsultaPredioUsuario ConsultaPredioUsuario;
        private Predio Predio;

        public ConsultarPredioUsuarioLogic(CityAppContext cityAppContext, ConsultaPredioUsuario consultaPredioUsuario)
        {
            PredioQuerys = new PredioQuerys(cityAppContext);

            ConsultaPredioUsuario = consultaPredioUsuario;
        }

        public Response<InformacionPagoPredio> Consultar()
        {
            Response<InformacionPagoPredio> response = new Response<InformacionPagoPredio>();

            Response<object> responseConsultaPredio = new Response<object>();

            responseConsultaPredio = PredioConsultar();
            response.Status = responseConsultaPredio.Status;

            if (response.Status.Exito == 1)
            {
                response.Data = new InformacionPagoPredio()
                {
                    IdPredio = Predio.IdPredio,
                    Clave = Predio.Clave,
                    ClaveCatastral = Predio.ClaveCatastral,
                    Atrasado = false,
                    Total = Predio.Total,
                    FechaUltimoPago = Predio.FechaUltimoPago,
                    PropietarioPagoPredio = new PropietarioPagoPredio()
                    {
                        Propietario = ConsultaPredioUsuario.Propietario,
                    },
                    DireccionPagoPredio = new DireccionPagoPredio()
                    {
                        Direccion = Predio.Direccion + ", " + Predio.Poblacion + ", " + Predio.Ciudad + ", " + Predio.Estado + ", " + Predio.CodigoPostal,
                    }
                };
            }

            return response;
        }

        private Response<object> PredioConsultar()
        {
            Response<object> response = new Response<object>();

            Response<Predio> responsePredio = PredioQuerys.SelectPredioConsultaPredioUsuario(ConsultaPredioUsuario);
            response.Status = responsePredio.Status;
            if (response.Status.Exito == 1)
            {
                Predio = responsePredio.Data;
            }

            return response;
        }
    }
}
