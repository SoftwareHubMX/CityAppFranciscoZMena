using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarTotalesBolsasTrabajoLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;
        private FiltroTotalBolsasTrabajo FiltroTotalBolsasTrabajo;

        public ConsultarTotalesBolsasTrabajoLogic(CityAppContext cityAppContext, FiltroTotalBolsasTrabajo filtroTotalBolsasTrabajo)
        {
            FiltroTotalBolsasTrabajo = filtroTotalBolsasTrabajo;
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContext);
        }

        public Response<List<DataSet>> Consultar()
        {
            Response<List<DataSet>> response = new Response<List<DataSet>>();

            int Total = 0;
            if (FiltroTotalBolsasTrabajo.FiltroFechas == 4)
            {
                response.Data = new List<DataSet>();
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        DataSet dataSet = new DataSet();
                        dataSet.Titulo = "Bolsas Activas";
                        dataSet.Items = new List<Item>();
                        for (int j = 1; j <= DateTime.DaysInMonth(FiltroTotalBolsasTrabajo.Year, FiltroTotalBolsasTrabajo.Mes); j++)
                        {
                            Response<IEnumerable<BolsaTrabajo>> responseTotal = new Response<IEnumerable<BolsaTrabajo>>();
                            responseTotal = BolsaTrabajoQuerys.SelectTotalBolsasTrabajoFechaEstatus(new DateTime(FiltroTotalBolsasTrabajo.Year, FiltroTotalBolsasTrabajo.Mes, j), true);
                            if (responseTotal.Status.Exito == 1)
                            {
                                dataSet.Items.Add(new Item()
                                {
                                    Cantidad = responseTotal.Data.ToList().Count,
                                    Descripcion = j.ToString(),
                                });
                                Total += responseTotal.Data != null ? 1 : 0;
                            }
                            else
                            {
                                dataSet.Items.Add(new Item()
                                {
                                    Cantidad = 0,
                                    Descripcion = j.ToString(),

                                });
                                Total += 0;
                            }
                        }
                        dataSet.CantidadTitulo = Total;
                        response.Data.Add(dataSet);
                    }
                    else if (i == 1)
                    {
                        DataSet dataSet = new DataSet();
                        dataSet.Titulo = "Bolsas Inactivas";
                        dataSet.Items = new List<Item>();
                        for (int j = 1; j <= DateTime.DaysInMonth(FiltroTotalBolsasTrabajo.Year, FiltroTotalBolsasTrabajo.Mes); j++)
                        {
                            Response<IEnumerable<BolsaTrabajo>> responseTotal = new Response<IEnumerable<BolsaTrabajo>>();
                            responseTotal = BolsaTrabajoQuerys.SelectTotalBolsasTrabajoFechaEstatus(new DateTime(FiltroTotalBolsasTrabajo.Year, FiltroTotalBolsasTrabajo.Mes, j), false);
                            if (responseTotal.Status.Exito == 1)
                            {
                                dataSet.Items.Add(new Item()
                                {
                                    Cantidad = responseTotal.Data.ToList().Count,
                                    Descripcion = j.ToString(),

                                });
                                Total += responseTotal.Data != null ? 1 : 0;
                            }
                            else
                            {
                                dataSet.Items.Add(new Item()
                                {
                                    Cantidad = 0,
                                    Descripcion = j.ToString(),

                                });
                                Total += 0;
                            }

                        }
                        dataSet.CantidadTitulo = Total - response.Data[0].CantidadTitulo;
                        response.Data.Add(dataSet);
                    }
                }
                response.Status.Exito = 1;
                response.Info.TotalData = Total;
            }
            return response;

        }

    }
}
