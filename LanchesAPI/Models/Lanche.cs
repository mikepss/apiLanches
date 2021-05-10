using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesAPI.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Adicional> Adicionais { get; set; }
    }

}
