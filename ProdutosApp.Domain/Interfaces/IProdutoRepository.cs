using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(Produto produto);

        List<Produto> GetAll();
        Produto? GetById(Guid id);
    }
}
