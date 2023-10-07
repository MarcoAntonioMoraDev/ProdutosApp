using AutoMapper;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Mappings
{
    /// <summary>
    /// Configuração dos mapeamentos feitos pelo AutoMapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutosPostModel, Produto>();
            
            CreateMap<ProdutosPutModel, Produto>();

            CreateMap<Produto, ProdutosGetModel>()
                .AfterMap((entity, model) =>
                {
                    model.Total = entity.Preco * entity.Quantidade;
                });
        }
    }
}
