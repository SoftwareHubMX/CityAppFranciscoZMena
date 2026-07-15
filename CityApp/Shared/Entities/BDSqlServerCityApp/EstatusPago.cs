using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class EstatusPago
    {
        [Key]
        public int IdEstatusPago { get; set; } = 0;
        public string Estatus { get; set; } = "NA";
    }
}
