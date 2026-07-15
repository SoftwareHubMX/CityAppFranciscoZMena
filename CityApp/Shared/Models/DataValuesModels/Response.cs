using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.DataValuesModels
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public Info Info { get; set; } = new Info();
        public Status Status { get; set; } = new Status();
    }
}
