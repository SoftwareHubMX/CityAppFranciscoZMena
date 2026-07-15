using CityApp.Shared.Models.DataValuesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers
{
    public class CargarStatus
    {
        public static Status Ok()
        {
            return new Status()
            {
                Exito = 1,
                Mensaje = "Ok"
            };
        }

        public static Status Error(Exception ex)
        {
            return new Status()
            {
                Exito = 0,
                Exception = ex.Message,
                Mensaje = "Error"
            };
        }

        public static Status Error(Exception ex, string mensaje)
        {
            return new Status()
            {
                Exito = 0,
                Exception = ex.Message,
                Mensaje = (mensaje != "NA" || mensaje != "") ? mensaje : "Error",
            };
        }
    }
}
