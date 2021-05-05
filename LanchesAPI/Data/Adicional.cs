using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesAPI.Data
{
    public class Adicional
    {
        public int id { get; set; }
        public int idLanche { get; set; }
        public int idIngrediente { get; set; }
    }
}
