using CityApp.Shared.Entities.BDSqlServerCityApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.PayModel
{
    public class PagoTarjeta
    {
        public string TokenId { get; set; } = "NA";
        public string DeviceSessionId { get; set; } = "NA";
        public string Description { get; set; } = "NA";
        public string Name { get; set; } = "NA";
        public string LastName { get; set; } = "NA";
        public string Email { get; set; } = "NA";
        public string PhoneNumber { get; set; } = "NA";
        public double Amount { get; set; } = 0;
        public int IdTipoPago { get; set; } = 0;
        public int IdPago { get; set; } = 0;
        public virtual Pago Pago { get; set; } = new Pago();
    }
}
