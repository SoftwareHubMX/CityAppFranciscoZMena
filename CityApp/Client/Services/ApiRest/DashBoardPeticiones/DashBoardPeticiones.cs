using CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.DashBoardPeticiones
{
    public class DashBoardPeticiones
    {
        private ConsultarComunicacion ConsultarComunicacion;
        private ConsultarDataSetIngresosYear ConsultarDataSetIngresosYear;
        private ConsultarDataSetReportesCiudadanos ConsultarDataSetReportesCiudadanos;
        private ConsultarUltimosIngresos ConsultarUltimosIngresos;
        private ConsultarDataSetTiposLugarTuristico ConsultarDataSetTiposLugarTuristico;
        private ConsultarTotalesBolsasTrabajo ConsultarTotalesBolsasTrabajo;
        private ConsultarDataSetTiposTramite ConsultarDataSetTiposTramite;

        public DashBoardPeticiones(HttpClient cliente)
        {
            ConsultarComunicacion = new ConsultarComunicacion(cliente);
            ConsultarDataSetIngresosYear = new ConsultarDataSetIngresosYear(cliente);
            ConsultarDataSetReportesCiudadanos = new ConsultarDataSetReportesCiudadanos(cliente);
            ConsultarUltimosIngresos = new ConsultarUltimosIngresos(cliente);
            ConsultarDataSetTiposLugarTuristico = new ConsultarDataSetTiposLugarTuristico(cliente);
            ConsultarTotalesBolsasTrabajo = new ConsultarTotalesBolsasTrabajo(cliente);
            ConsultarDataSetTiposTramite = new ConsultarDataSetTiposTramite(cliente);   
        }

        public async Task<Response<List<ChartData>>> consultarComunicacion(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await ConsultarComunicacion.ConsultarComunicacionAsync(fechasDashBoard, token);
            return response;
        }
        public async Task<Response<List<ChartData>>> consultarTiposLugarTuristico(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await ConsultarDataSetTiposLugarTuristico.ConsultarTiposLugarTuristicoAsync(fechasDashBoard, token);
            return response;
        }

        public async Task<Response<List<ChartData>>> consultarDataSetIngresosYear(FechasDashBoard fechasDashBoard,string token)
        {
            Response<List<ChartData>> response = await ConsultarDataSetIngresosYear.ConsultarDataSetIngresosYearAsync(fechasDashBoard, token);
            return response;
        }

        public async Task<Response<List<ChartData>>> consultarDataSetReportesCiudadanos(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await ConsultarDataSetReportesCiudadanos.ConsultarDataSetReportesCiudadanosAsync(fechasDashBoard, token);
            return response;
        }

        public async Task<Response<List<UltimoPago>>> consultarUltimosIngresos(string token)
        {
            Response<List<UltimoPago>> response = await ConsultarUltimosIngresos.ConsultarUltimosIngresosAsync(token);
            return response;
        }
        public async Task<Response<List<DataSet>>> consultarTotalesBolsasTrabajo(FiltroTotalBolsasTrabajo filtroTotalBolsasTrabajo, string token)
        {
            Response<List<DataSet>> response = await ConsultarTotalesBolsasTrabajo.ConsultarTotalesBolsasTrabajoAsync(filtroTotalBolsasTrabajo, token);
            return response;
        }
        public async Task<Response<List<ChartData>>> consultarTiposTramite(FechasDashBoard fechasDashBoard, string token)
        {
            Response<List<ChartData>> response = await ConsultarDataSetTiposTramite.ConsultarTiposTramiteAsync(fechasDashBoard, token);
            return response;
        }
    }
}
