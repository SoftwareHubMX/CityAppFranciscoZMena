using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels
{
    public class DataSet
    {
        public string Titulo { get; set; } = "";
        public string SubTitulo { get; set; } = "";
        public double CantidadTitulo { get; set; } = 0;
        public double CantidadSubTitulo { get; set; } = 0;
        //public string SubTitulo2 { get; set; } = "";
        //public double CantidadSubTitulo2 { get; set; } = 0;
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
