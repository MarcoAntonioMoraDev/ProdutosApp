namespace ProdutosApp.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisição do serviço de consulta de produtos
    /// </summary>
    public class ProdutosGetModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
    }
}
