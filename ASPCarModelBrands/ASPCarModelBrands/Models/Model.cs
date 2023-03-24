using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCarModelBrands.Models
{
    public class Model
    {
        public int id { get; set; }
        public int brandid { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
    }
}
