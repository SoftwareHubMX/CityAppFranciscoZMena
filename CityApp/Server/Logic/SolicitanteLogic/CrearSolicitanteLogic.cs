using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitanteQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitanteLogic
{
    public class CrearSolicitanteLogic
    {
        private SolicitanteQuerys SolicitanteQuerys;

        private Solicitante Solicitante;

        public CrearSolicitanteLogic(CityAppContext cityAppContext, Solicitante solicitante)
        {
            SolicitanteQuerys = new SolicitanteQuerys(cityAppContext);

            Solicitante = solicitante;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsert = new Response<object>();
            responseInsert = SolicitanteQuerys.InsertSolicitud(Solicitante);
            response.Status = responseInsert.Status;
            if (response.Status.Exito == 1)
            {
                Response<Solicitante> responseColonia = new Response<Solicitante>();
                responseColonia = SolicitanteQuerys.SelectLastIdSolicitante();
                response.Status = responseColonia.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = responseColonia.Data.IdSolicitante;
                }

            }
            return response;
        }
        //public Response<object> Crear()
        //{
        //    return SolicitanteQuerys.InsertSolicitud(Solicitante);
        //}
    }
}
