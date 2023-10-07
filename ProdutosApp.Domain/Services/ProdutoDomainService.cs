using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        //atributo
        private readonly IProdutoRepository? _produtoRepository;

        //construtor para inicializar o atributo
        public ProdutoDomainService(IProdutoRepository? produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            produto.DataCriacao = DateTime.Now;
            produto.DataUltimaAlteracao = DateTime.Now;
            produto.Ativo = 1;

            _produtoRepository?.Add(produto);
        }

        public void Alterar(Produto produto)
        {
            var registro = _produtoRepository?.GetById(produto.Id);

            if(registro != null)
            {
                registro.Nome = produto.Nome;
                registro.Descricao = produto.Descricao;
                registro.Preco = produto.Preco;
                registro.Quantidade = produto.Quantidade;
                registro.DataUltimaAlteracao = DateTime.Now;

                _produtoRepository?.Update(registro);

                produto.DataCriacao = registro.DataCriacao;
                produto.DataUltimaAlteracao = registro.DataUltimaAlteracao;
            }
            else
            {
                throw new ApplicationException("Produto não encontrado, verifique o ID informado.");
            }
        }

        public void Excluir(Guid id)
        {
            var registro = _produtoRepository?.GetById(id);

            if (registro != null)
            {                
                _produtoRepository?.Delete(registro);
            }
            else
            {
                throw new ApplicationException("Produto não encontrado, verifique o ID informado.");
            }
        }

        public List<Produto> ObterTodos()
        {
            return _produtoRepository?.GetAll();
        }

        public Produto? ObterPorId(Guid id)
        {
            return _produtoRepository?.GetById(id);
        }
    }
}
