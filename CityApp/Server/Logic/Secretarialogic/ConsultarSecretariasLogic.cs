using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.Secretarialogic
{
    public class ConsultarSecretariasLogic
    {
        private SecretariaQuerys SecretariaQuerys;
        private List<Secretaria> Secretaria;
        

        public ConsultarSecretariasLogic(CityAppContext cityAppContex)
        {
            SecretariaQuerys = new SecretariaQuerys(cityAppContex);
        }

        public Response<List<Secretaria>> Consultar()
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();

            Response<IEnumerable<Secretaria>> responseSecretaria = SecretariaQuerys.SelectSecretarias();
            response.Status = responseSecretaria.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Secretaria>();
                response.Data = responseSecretaria.Data.ToList();
            }

            return response;
        }
    }
}
