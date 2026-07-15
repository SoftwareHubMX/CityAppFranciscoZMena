using CityApp.Client.Services.ApiRest.PatrullaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaPatrullaLogic
{
    public class SelectPatrullas
    {
        private PatrullaPeticiones PatrullaPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectPatrullas(HttpClient cliente)
        {
            PatrullaPeticiones = new PatrullaPeticiones(cliente);
        }

        public async Task<Response<List<Patrulla>>> SelectAll(string token, FiltroPatrullas filtroPatrullas)
        {
            filtroPatrullas.Placa = (filtroPatrullas.Placa != "" && filtroPatrullas.Placa != "NA") ? Codificador.Encrypt(filtroPatrullas.Placa) : "NA";
            filtroPatrullas.NumeroEconomico = (filtroPatrullas.NumeroEconomico != "" && filtroPatrullas.NumeroEconomico != "NA") ? Codificador.Encrypt(filtroPatrullas.NumeroEconomico) : "NA";
            Response<List<Patrulla>> response = await PatrullaPeticiones.consultarPatrullas(token, filtroPatrullas);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.Count; i++)
                {
                    response.Data[i].Placa = (response.Data[i].Placa != "NA") ? Codificador.Decrypt(response.Data[i].Placa) : "NA";
                    response.Data[i].NumeroEconomico = (response.Data[i].NumeroEconomico != "NA") ? Codificador.Decrypt(response.Data[i].NumeroEconomico) : "NA";
                }
            }
            filtroPatrullas.Placa = (filtroPatrullas.Placa != "" && filtroPatrullas.Placa != "NA") ? Codificador.Decrypt(filtroPatrullas.Placa) : "NA";
            filtroPatrullas.NumeroEconomico = (filtroPatrullas.NumeroEconomico != "" && filtroPatrullas.NumeroEconomico != "NA") ? Codificador.Decrypt(filtroPatrullas.NumeroEconomico) : "NA";
            return response;
        }
    }
}
