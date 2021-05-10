using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesAPI.Models
{
    public class Adicional
    {
        public int LancheId { get; set; }
        public Lanche Lanche { get; set; }
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
