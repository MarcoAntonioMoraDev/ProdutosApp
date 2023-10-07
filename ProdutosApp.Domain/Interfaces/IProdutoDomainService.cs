using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces
{
    public interface IProdutoDomainService
    {
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Excluir(Guid id);

        List<Produto> ObterTodos();
        Produto? ObterPorId(Guid id);
    }
}
