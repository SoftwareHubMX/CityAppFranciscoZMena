using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.Secretarialogic
{
    public class ConsultarSecretariasFiltroLogic
    {
        private SecretariaQuerys SecretariaQuerys;
        private List<Secretaria> Secretaria;
        private FiltroSecretaria FiltroSecretaria;


        public ConsultarSecretariasFiltroLogic(CityAppContext cityAppContex, FiltroSecretaria filtroSecretaria)
        {
            SecretariaQuerys = new SecretariaQuerys(cityAppContex);
            FiltroSecretaria = filtroSecretaria;
        }

        public Response<List<Secretaria>> Consultar()
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();

            Response<IEnumerable<Secretaria>> responseSecretaria = SecretariaQuerys.SelectSecretariasFirltoSecretaria(FiltroSecretaria);
            response.Status = responseSecretaria.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Secretaria>();
                response.Data = responseSecretaria.Data.ToList();
                response.Info = new Info(); 
                response.Info = responseSecretaria.Info;
            }

            return response;
        }
    }
}
