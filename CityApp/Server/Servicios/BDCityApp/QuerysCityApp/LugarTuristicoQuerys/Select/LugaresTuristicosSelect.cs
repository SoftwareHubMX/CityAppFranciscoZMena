using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.EntityFrameworkCore;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Select
{
    public class LugaresTuristicosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<LugarTuristico> SelectCityApp = new SelectCityApp<LugarTuristico>();

        private Paginado<LugarTuristico> Paginado = new Paginado<LugarTuristico>();

        public LugaresTuristicosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<LugarTuristico>> SelectLugaresTuristicosFiltros(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            Response<IEnumerable<LugarTuristico>> response = new Response<IEnumerable<LugarTuristico>>();

            try
            {
                response.Data = from data in CityAppContext.LugaresTuristicos
                                orderby data.IdLugarTuristico
                                where (filtroLugaresTuristicos.Busqueda != "NA") ?
                                    data.Nombre.Contains(filtroLugaresTuristicos.Busqueda)
                                    || data.Descripcion.Contains(filtroLugaresTuristicos.Busqueda)
                                    || data.CaracteristicasLugarTuristico.Any(d =>
                                    d.Caracteristica.Contains(filtroLugaresTuristicos.Busqueda)
                                    || d.NombreCaracteristica.Contains(filtroLugaresTuristicos.Busqueda)) : true
                                    && (filtroLugaresTuristicos.Nombre != "NA") ?
                                        data.Nombre.Contains(filtroLugaresTuristicos.Nombre)
                                        : true
                                    && (filtroLugaresTuristicos.Descripcion != "NA") ?
                                        data.Descripcion.Contains(filtroLugaresTuristicos.Descripcion)
                                        : true
                                    && (filtroLugaresTuristicos.Caracteristica != "NA") ?
                                        data.CaracteristicasLugarTuristico.Any(d =>
                                        d.NombreCaracteristica.Contains(filtroLugaresTuristicos.Caracteristica))
                                        : true
                                    && (filtroLugaresTuristicos.CaracteristicaData != "NA") ?
                                        data.CaracteristicasLugarTuristico.Any(d =>
                                        d.Caracteristica.Contains(filtroLugaresTuristicos.CaracteristicaData))
                                        : true
                                    && (filtroLugaresTuristicos.Localidad != "NA") ?
                                        data.DireccionLugarTuristico.Localidad.Contains(filtroLugaresTuristicos.Localidad)
                                        : true
                                    && (filtroLugaresTuristicos.Colonia != "NA") ?
                                        data.DireccionLugarTuristico.Colonia.Contains(filtroLugaresTuristicos.Colonia)
                                        : true
                                    && (filtroLugaresTuristicos.Calle != "NA") ?
                                        data.DireccionLugarTuristico.Calle.Contains(filtroLugaresTuristicos.Calle)
                                        : true
                                    && (filtroLugaresTuristicos.Numero != "NA") ?
                                        data.DireccionLugarTuristico.Numero.Contains(filtroLugaresTuristicos.Numero)
                                        : true
                                    && (filtroLugaresTuristicos.CodigoPostal != "NA") ?
                                        data.DireccionLugarTuristico.CodigoPostal.Contains(filtroLugaresTuristicos.CodigoPostal)
                                        : true
                                select new LugarTuristico()
                                {
                                    IdLugarTuristico = data.IdLugarTuristico,
                                    Nombre = data.Nombre,
                                    Descripcion = data.Descripcion,
                                    IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                    FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                    TipoLugarTuristico = data.TipoLugarTuristico,
                                    Telefono = data.Telefono,
                                    UrlWebFacebook = data.UrlWebFacebook,
                                    DireccionLugarTuristico = data.DireccionLugarTuristico,
                                    CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                    ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response.Data = from data in response.Data
                                    orderby data.IdLugarTuristico
                                    where (filtroLugaresTuristicos.IdTipoLugarTuristico != 0) ?
                                            data.IdTipoLugarTuristico == filtroLugaresTuristicos.IdTipoLugarTuristico
                                            : true
                                    select new LugarTuristico()
                                    {
                                        IdLugarTuristico = data.IdLugarTuristico,
                                        Nombre = data.Nombre,
                                        Descripcion = data.Descripcion,
                                        IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                        FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                        TipoLugarTuristico = data.TipoLugarTuristico,
                                        Telefono = data.Telefono,
                                        UrlWebFacebook = data.UrlWebFacebook,
                                        DireccionLugarTuristico = data.DireccionLugarTuristico,
                                        CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                        ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                    };

                    response.Status = SelectCityApp.ValidarLista(response.Data);
                    if (response.Status.Exito == 1)
                    {
                        response.Data = from data in response.Data
                                        orderby data.IdLugarTuristico
                                        where (filtroLugaresTuristicos.FiltroFechas == 1) ?
                                        data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.FechaFija.Year, filtroLugaresTuristicos.FechaFija.Month, filtroLugaresTuristicos.FechaFija.Day, 0, 0, 0)
                                        && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.FechaFija.Year, filtroLugaresTuristicos.FechaFija.Month, filtroLugaresTuristicos.FechaFija.Day, 23, 59, 59)
                                            : (filtroLugaresTuristicos.FiltroFechas == 2) ?
                                                data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.FechaInicio.Year, filtroLugaresTuristicos.FechaInicio.Month, filtroLugaresTuristicos.FechaInicio.Day, 0, 0, 0)
                                                && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.FechaFin.Year, filtroLugaresTuristicos.FechaFin.Month, filtroLugaresTuristicos.FechaFin.Day, 23, 59, 59)
                                            : (filtroLugaresTuristicos.FiltroFechas == 3) ?
                                                data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.Year, 1, 1, 0, 0, 0)
                                                && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.Year, 12, 31, 23, 59, 59)
                                            : (filtroLugaresTuristicos.FiltroFechas == 4) ?
                                                data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.Year, filtroLugaresTuristicos.Mes, 1, 0, 0, 0)
                                                && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.Year, filtroLugaresTuristicos.Mes, DateTime.DaysInMonth(filtroLugaresTuristicos.Year, filtroLugaresTuristicos.Mes), 23, 59, 59)
                                            : true
                                        select new LugarTuristico()
                                        {
                                            IdLugarTuristico = data.IdLugarTuristico,
                                            Nombre = data.Nombre,
                                            Descripcion = data.Descripcion,
                                            IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                            FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                            TipoLugarTuristico = data.TipoLugarTuristico,
                                            Telefono = data.Telefono,
                                            UrlWebFacebook = data.UrlWebFacebook,
                                            DireccionLugarTuristico = data.DireccionLugarTuristico,
                                            CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                            ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                        };

                        response.Status = SelectCityApp.ValidarLista(response.Data);

                        if (response.Status.Exito == 1)
                        {
                            switch (filtroLugaresTuristicos.Orden)
                            {
                                case 1:
                                    response.Data = response.Data.OrderBy(d => d.IdLugarTuristico);
                                    break;
                                case 2:
                                    response.Data = response.Data.OrderByDescending(d => d.IdLugarTuristico);
                                    break;
                                case 3:
                                    response.Data = response.Data.OrderBy(d => d.Nombre);
                                    break;
                                case 4:
                                    response.Data = response.Data.OrderByDescending(d => d.Nombre);
                                    break;
                                case 5:
                                    response.Data = response.Data.OrderBy(d => d.Descripcion);
                                    break;
                                case 6:
                                    response.Data = response.Data.OrderByDescending(d => d.Descripcion);
                                    break;
                                case 7:
                                    response.Data = response.Data.OrderBy(d => d.IdTipoLugarTuristico);
                                    break;
                                case 8:
                                    response.Data = response.Data.OrderByDescending(d => d.IdTipoLugarTuristico);
                                    break;
                                case 9:
                                    response.Data = response.Data.OrderBy(d => d.DireccionLugarTuristico.Calle);
                                    break;
                                case 10:
                                    response.Data = response.Data.OrderByDescending(d => d.DireccionLugarTuristico.Calle);
                                    break;
                                case 11:
                                    response.Data = response.Data.OrderBy(d => d.FechaFundacionConstruccionApertura);
                                    break;
                                case 12:
                                    response.Data = response.Data.OrderByDescending(d => d.FechaFundacionConstruccionApertura);
                                    break;
                                default:
                                    response.Data = response.Data.OrderByDescending(d => d.IdLugarTuristico);
                                    break;
                            }

                            response = Paginado.Paginar(response.Data, filtroLugaresTuristicos.MaximoNoticias, filtroLugaresTuristicos.Pagina);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<LugarTuristico>> SelectLugarTuristicoTiposLugarTuristico(int idTipoLugarTuristico, FechasDashBoard fechasDashBoard)
        {
            Response<IEnumerable<LugarTuristico>> response = new Response<IEnumerable<LugarTuristico>>();

            try
            {
                response.Data = from data in CityAppContext.LugaresTuristicos
                                where data.IdTipoLugarTuristico == idTipoLugarTuristico
                                select new LugarTuristico()
                                {
                                    IdLugarTuristico = data.IdLugarTuristico,
                                    Nombre = data.Nombre,
                                    Telefono = data.Telefono,
                                    UrlWebFacebook = data.UrlWebFacebook,
                                    Descripcion = data.Descripcion,
                                    IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                    FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
        public Response<IEnumerable<LugarTuristico>> SelectLugaresTuristicosAppAleatorio(FiltroLugaresTuristicos filtroLugaresTuristicos)
        {
            Response<IEnumerable<LugarTuristico>> response = new Response<IEnumerable<LugarTuristico>>();

            try
            {
                response.Data = from data in CityAppContext.LugaresTuristicos
                                orderby data.IdLugarTuristico
                                where (filtroLugaresTuristicos.Busqueda != "NA") ?
                                    data.Nombre.Contains(filtroLugaresTuristicos.Busqueda)
                                    || data.Descripcion.Contains(filtroLugaresTuristicos.Busqueda)
                                    || data.CaracteristicasLugarTuristico.Any(d =>
                                    d.Caracteristica.Contains(filtroLugaresTuristicos.Busqueda)
                                    || d.NombreCaracteristica.Contains(filtroLugaresTuristicos.Busqueda)) : true
                                    && (filtroLugaresTuristicos.Nombre != "NA") ?
                                        data.Nombre.Contains(filtroLugaresTuristicos.Nombre)
                                        : true
                                    && (filtroLugaresTuristicos.Descripcion != "NA") ?
                                        data.Descripcion.Contains(filtroLugaresTuristicos.Descripcion)
                                        : true
                                    && (filtroLugaresTuristicos.Caracteristica != "NA") ?
                                        data.CaracteristicasLugarTuristico.Any(d =>
                                        d.NombreCaracteristica.Contains(filtroLugaresTuristicos.Caracteristica))
                                        : true
                                    && (filtroLugaresTuristicos.CaracteristicaData != "NA") ?
                                        data.CaracteristicasLugarTuristico.Any(d =>
                                        d.Caracteristica.Contains(filtroLugaresTuristicos.CaracteristicaData))
                                        : true
                                    && (filtroLugaresTuristicos.Localidad != "NA") ?
                                        data.DireccionLugarTuristico.Localidad.Contains(filtroLugaresTuristicos.Localidad)
                                        : true
                                    && (filtroLugaresTuristicos.Colonia != "NA") ?
                                        data.DireccionLugarTuristico.Colonia.Contains(filtroLugaresTuristicos.Colonia)
                                        : true
                                    && (filtroLugaresTuristicos.Calle != "NA") ?
                                        data.DireccionLugarTuristico.Calle.Contains(filtroLugaresTuristicos.Calle)
                                        : true
                                    && (filtroLugaresTuristicos.Numero != "NA") ?
                                        data.DireccionLugarTuristico.Numero.Contains(filtroLugaresTuristicos.Numero)
                                        : true
                                    && (filtroLugaresTuristicos.CodigoPostal != "NA") ?
                                        data.DireccionLugarTuristico.CodigoPostal.Contains(filtroLugaresTuristicos.CodigoPostal)
                                        : true
                                select new LugarTuristico()
                                {
                                    IdLugarTuristico = data.IdLugarTuristico,
                                    Nombre = data.Nombre,
                                    Descripcion = data.Descripcion,
                                    IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                    FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                    TipoLugarTuristico = data.TipoLugarTuristico,
                                    Telefono = data.Telefono,   
                                    UrlWebFacebook = data.UrlWebFacebook,   
                                    DireccionLugarTuristico = data.DireccionLugarTuristico,
                                    CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                    ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response.Data = from data in response.Data
                                    orderby data.IdLugarTuristico
                                    where (filtroLugaresTuristicos.IdTipoLugarTuristico != 0) ?
                                            data.IdTipoLugarTuristico == filtroLugaresTuristicos.IdTipoLugarTuristico
                                            : true
                                    select new LugarTuristico()
                                    {
                                        IdLugarTuristico = data.IdLugarTuristico,
                                        Nombre = data.Nombre,                                   
                                        Descripcion = data.Descripcion,
                                        IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                        FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                        TipoLugarTuristico = data.TipoLugarTuristico,
                                        Telefono = data.Telefono,
                                        UrlWebFacebook = data.UrlWebFacebook,
                                        DireccionLugarTuristico = data.DireccionLugarTuristico,
                                        CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                        ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                    };

                    response.Status = SelectCityApp.ValidarLista(response.Data);
                    if (response.Status.Exito == 1)
                    {
                        response.Data = from data in response.Data
                                        orderby data.IdLugarTuristico
                                        where (filtroLugaresTuristicos.FiltroFechas == 1) ?
                                        data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.FechaFija.Year, filtroLugaresTuristicos.FechaFija.Month, filtroLugaresTuristicos.FechaFija.Day, 0, 0, 0)
                                        && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.FechaFija.Year, filtroLugaresTuristicos.FechaFija.Month, filtroLugaresTuristicos.FechaFija.Day, 23, 59, 59)
                                            : (filtroLugaresTuristicos.FiltroFechas == 2) ?
                                                data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.FechaInicio.Year, filtroLugaresTuristicos.FechaInicio.Month, filtroLugaresTuristicos.FechaInicio.Day, 0, 0, 0)
                                                && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.FechaFin.Year, filtroLugaresTuristicos.FechaFin.Month, filtroLugaresTuristicos.FechaFin.Day, 23, 59, 59)
                                            : (filtroLugaresTuristicos.FiltroFechas == 3) ?
                                                data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.Year, 1, 1, 0, 0, 0)
                                                && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.Year, 12, 31, 23, 59, 59)
                                            : (filtroLugaresTuristicos.FiltroFechas == 4) ?
                                                data.FechaFundacionConstruccionApertura >= new DateTime(filtroLugaresTuristicos.Year, filtroLugaresTuristicos.Mes, 1, 0, 0, 0)
                                                && data.FechaFundacionConstruccionApertura <= new DateTime(filtroLugaresTuristicos.Year, filtroLugaresTuristicos.Mes, DateTime.DaysInMonth(filtroLugaresTuristicos.Year, filtroLugaresTuristicos.Mes), 23, 59, 59)
                                            : true
                                        select new LugarTuristico()
                                        {
                                            IdLugarTuristico = data.IdLugarTuristico,
                                            Nombre = data.Nombre,
                                            Descripcion = data.Descripcion,
                                            IdTipoLugarTuristico = data.IdTipoLugarTuristico,
                                            FechaFundacionConstruccionApertura = data.FechaFundacionConstruccionApertura,
                                            TipoLugarTuristico = data.TipoLugarTuristico,
                                            Telefono = data.Telefono,
                                            UrlWebFacebook = data.UrlWebFacebook,
                                            DireccionLugarTuristico = data.DireccionLugarTuristico,
                                            CaracteristicasLugarTuristico = data.CaracteristicasLugarTuristico,
                                            ArchivosLugarTuristico = data.ArchivosLugarTuristico,
                                        };

                        response.Status = SelectCityApp.ValidarLista(response.Data);

                        if (response.Status.Exito == 1)
                        {
                            switch (filtroLugaresTuristicos.Orden)
                            {
                                case 1:
                                    response.Data = response.Data.OrderBy(d => d.IdLugarTuristico);
                                    break;
                                case 2:
                                    response.Data = response.Data.OrderByDescending(d => d.IdLugarTuristico);
                                    break;
                                case 3:
                                    response.Data = response.Data.OrderBy(d => d.Nombre);
                                    break;
                                case 4:
                                    response.Data = response.Data.OrderByDescending(d => d.Nombre);
                                    break;
                                case 5:
                                    response.Data = response.Data.OrderBy(d => d.Descripcion);
                                    break;
                                case 6:
                                    response.Data = response.Data.OrderByDescending(d => d.Descripcion);
                                    break;
                                case 7:
                                    response.Data = response.Data.OrderBy(d => d.IdTipoLugarTuristico);
                                    break;
                                case 8:
                                    response.Data = response.Data.OrderByDescending(d => d.IdTipoLugarTuristico);
                                    break;
                                case 9:
                                    response.Data = response.Data.OrderBy(d => d.DireccionLugarTuristico.Calle);
                                    break;
                                case 10:
                                    response.Data = response.Data.OrderByDescending(d => d.DireccionLugarTuristico.Calle);
                                    break;
                                case 11:
                                    response.Data = response.Data.OrderBy(d => d.FechaFundacionConstruccionApertura);
                                    break;
                                case 12:
                                    response.Data = response.Data.OrderByDescending(d => d.FechaFundacionConstruccionApertura);
                                    break;
                                default:
                                    response.Data = response.Data.OrderByDescending(d => d.IdLugarTuristico);
                                    break;
                            }

                            response = Paginado.Paginar(response.Data, filtroLugaresTuristicos.MaximoNoticias, filtroLugaresTuristicos.Pagina);
                        }
                    }
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
