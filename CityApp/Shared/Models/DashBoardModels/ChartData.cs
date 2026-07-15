using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.DashBoardModels
{
    public class ChartData
    {
        public string Label { get; set; } = "";
        public List<double> Data { get; set; } = new List<double>();
        public string ImageSource { get; set; }
    }
}
