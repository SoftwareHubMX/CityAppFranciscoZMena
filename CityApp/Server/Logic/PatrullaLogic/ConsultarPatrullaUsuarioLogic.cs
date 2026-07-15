using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PatrullaLogic
{
    public class ConsultarPatrullaUsuarioLogic
    {
        private PatrullaQuerys PatrullaQuerys;
        private string Placa = "";
        private string Numero = "";

        public ConsultarPatrullaUsuarioLogic(CityAppContext cityAppContext, string placa, string numero)
        {
            PatrullaQuerys = new PatrullaQuerys(cityAppContext);

            Placa = placa;
            Numero = numero;
        }

        public Response<Patrulla> Consultar()
        {
            return PatrullaQuerys.SelectPatrulla(Placa, Numero);
        }
    }
}
