using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SponteBackEnd.Data;
using SponteBackEnd.Models;
using SponteBackEnd.ViewModels.ProductViewModels;

namespace SponteBackEnd.Repositories
{
    public class ProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context
                .Produtos
                .Include(x => x.ProdutoCategoria)
                .Select(x => new ListProductViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    Valor = x.Valor,
                    Altura = x.Altura,
                    Largura = x.Largura,
                    Comprimento = x.Comprimento,
                    Peso = x.Peso,
                    CodigoBarras = x.CodigoBarras,
                    DataAquisicao = x.DataAquisicao,
                    Imagem = x.Imagem,
                    Categorias = x.ProdutoCategoria.Select(c => c.Categoria).ToList()
                })
                .AsNoTracking()
                .ToList();
        }
        public Produto Get(int id)
        {
            return _context.Produtos.Find(id);
        }
        public void Save(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        public void Update(Produto produto)
        {
            _context.Entry<Produto>(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}