using ProdutosApp.Data.Contexts;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public void Add(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(produto);
                dataContext.SaveChanges();
            }
        }

        public void Update(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Produto produto)
        {
            produto.Ativo = 0;
            Update(produto);
        }

        public List<Produto> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produtos
                    .Where(p => p.Ativo == 1)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        public Produto? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produtos
                    .Where(p => p.Id == id && p.Ativo == 1)
                    .FirstOrDefault();
            }
        }
    }
}
