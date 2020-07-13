using System;
using System.Collections.Generic;

namespace SponteBackEnd.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float Altura { get; set; }
        public float Largura { get; set; }
        public float Comprimento { get; set; }
        public float Peso { get; set; }
        public int CodigoBarras { get; set; }
        public ICollection<ProdutoCategoria> ProdutoCategoria { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Imagem { get; set; }
    }
}