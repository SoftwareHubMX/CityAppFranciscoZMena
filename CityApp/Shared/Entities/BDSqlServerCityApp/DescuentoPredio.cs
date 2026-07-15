using CityApp.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Entities.BDSqlServerCityApp
{
    public class DescuentoPredio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDescuentoPredio { get; set; } = 0;
        public string TituloDescuento { get; set; } = "NA";
        public DateTime FechaInicio { get; set; } = Fecha.GetFechaMx();
        public DateTime FechaFin { get; set; } = Fecha.GetFechaMx();
        public int YearResago { get; set; } = 0;
        public bool PorsentajeMonto { get; set; } = false;
        //false = porcentaje
        public double Descuento { get; set; } = 0;
    }
}
