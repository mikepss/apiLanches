using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesAPI.Data
{
    public class Lanche
    {
        public int id { get; set; }
        public string nome { get; set; }
        public List<Adicional> adicionais { get; set; } = new List<Adicional>();
    }

}
