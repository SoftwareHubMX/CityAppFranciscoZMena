using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.SignalR;

namespace CityApp.Server
{
    public class NotificacionesHub : Hub
    {
        private CityAppContext CityAppContext;
        private CuentaQuerys CuentaQuerys;

        private static Dictionary<int, List<string>> CuentasKeys;
        private static Dictionary<string, int> KeysCuentas;

        private ServicioValidarPeticionSimple servicioValidarPeticionSimple = new ServicioValidarPeticionSimple();

        public NotificacionesHub(CityAppContext cityAppContext)
        {
            CuentasKeys = CuentasKeys ?? new Dictionary<int, List<string>>();
            KeysCuentas = KeysCuentas ?? new Dictionary<string, int>();

            CuentaQuerys = new CuentaQuerys(cityAppContext);
        }

        //Nos avisa por la consola cuando algien se conecta
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("Conexion: " + Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task Conectar(Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = servicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                if (CuentasKeys.ContainsKey(peticion.Data))
                {
                    CuentasKeys[peticion.Data].Add(Context.ConnectionId);
                    KeysCuentas.Add(Context.ConnectionId, peticion.Data);
                }
                else
                {
                    CuentasKeys.Add(peticion.Data, new List<string>() { Context.ConnectionId });
                    KeysCuentas.Add(Context.ConnectionId, peticion.Data);
                }
            }
            await Clients.Client(Context.ConnectionId).SendAsync("ConectarRespuesta", response);
        }

        public async Task NuevoReporte(Peticion<object> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = servicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                Response<IEnumerable<int>> responseIdsCuenta = CuentaQuerys.SelectIdsCuentaIdRol(1);
                response.Status = responseIdsCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    foreach (var idCuenta in responseIdsCuenta.Data)
                    {
                        List<string> keys = (CuentasKeys.ContainsKey(idCuenta)) ? CuentasKeys[idCuenta] : new List<string>();
                        foreach (string key in keys)
                        {
                            await Clients.Client(key).SendAsync("NotificacionNuevoReporte", response);
                        }
                    }
                }
            }
            await Clients.Client(Context.ConnectionId).SendAsync("RespuestaNuevoReporte", response);
        }

        public async Task ActualizacionEstatus(Peticion<int> peticion)
        {
            Response<int> response = new Response<int>();
            Response<object> responseValidarPeticion = servicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                Response<IEnumerable<int>> responseIdsCuenta = CuentaQuerys.SelectIdsCuentaIdReporteCiudadano(peticion.Data);
                response.Status = responseIdsCuenta.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = peticion.Data;
                    foreach (var idCuenta in responseIdsCuenta.Data)
                    {
                        List<string> keys = (CuentasKeys.ContainsKey(idCuenta)) ? CuentasKeys[idCuenta] : new List<string>();
                        foreach (string key in keys)
                        {
                            await Clients.Client(key).SendAsync("NotificacionActualizacionEstatus", response);
                        }
                    }
                }
            }
            await Clients.Client(Context.ConnectionId).SendAsync("RespuestaActualizacionEstatus", response);
        }

        public async Task Desconectar(Peticion<object> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = servicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                string key = Context.ConnectionId;
                int idCuenta = KeysCuentas.ContainsKey(key) ? KeysCuentas[key] : 0;
                if (key != "")
                {
                    KeysCuentas.Remove(key);
                    CuentasKeys[idCuenta].Remove(key);
                    if (CuentasKeys[idCuenta].Count == 0)
                    {
                        CuentasKeys.Remove(idCuenta);
                    }
                }
            }
            await Clients.Client(Context.ConnectionId).SendAsync("RespuestaDesconectar", response);
            Console.WriteLine("Desconexion: " + Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            string key = Context.ConnectionId;
            int idCuenta = KeysCuentas.ContainsKey(key) ? KeysCuentas[key] : 0;
            if (key != "")
            {
                KeysCuentas.Remove(key);
                CuentasKeys[idCuenta].Remove(key);
                if (CuentasKeys[idCuenta].Count == 0)
                {
                    CuentasKeys.Remove(idCuenta);
                }
            }
            Console.WriteLine("Desconexion: " + Context.ConnectionId);
        }
    }
}
