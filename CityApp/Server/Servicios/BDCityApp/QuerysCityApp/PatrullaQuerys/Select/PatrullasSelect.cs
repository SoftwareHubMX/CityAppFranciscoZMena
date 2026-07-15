using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Select
{
    public class PatrullasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Patrulla> SelectCityApp = new SelectCityApp<Patrulla>();

        private Paginado<Patrulla> Paginado = new Paginado<Patrulla>();

        public PatrullasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Patrulla>> SelectPatrullasFiltroPatrullas(FiltroPatrullas filtroPatrullas)
        {
            Response<IEnumerable<Patrulla>> response = new Response<IEnumerable<Patrulla>>();

            try
            {
                response.Data = CityAppContext.Patrullas;

                if (filtroPatrullas.Placa != "NA")
                {
                    response.Data = response.Data.Where(d => d.Placa == filtroPatrullas.Placa);
                }

                if (filtroPatrullas.NumeroEconomico != "NA")
                {
                    response.Data = response.Data.Where(d => d.NumeroEconomico == filtroPatrullas.NumeroEconomico);
                }

                switch (filtroPatrullas.Orden)
                {
                    case 0:
                        response.Data = response.Data;
                        break;
                    case 1:
                        response.Data = response.Data.OrderBy(d => d.IdPatrulla);
                        break;
                    case 2:
                        response.Data = response.Data.OrderByDescending(d => d.IdPatrulla);
                        break;
                    case 3:
                        response.Data = response.Data.OrderBy(d => d.Placa);
                        break;
                    case 4:
                        response.Data = response.Data.OrderByDescending(d => d.Placa);
                        break;
                    case 5:
                        response.Data = response.Data.OrderBy(d => d.NumeroEconomico);
                        break;
                    case 6:
                        response.Data = response.Data.OrderByDescending(d => d.NumeroEconomico);
                        break;
                    default:
                        response.Data = response.Data;
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroPatrullas.MaximoPatrullas, filtroPatrullas.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
