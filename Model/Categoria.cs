using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SponteBackEnd.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public ICollection<ProdutoCategoria> ProdutoCategoria { get; set; }
    }
}