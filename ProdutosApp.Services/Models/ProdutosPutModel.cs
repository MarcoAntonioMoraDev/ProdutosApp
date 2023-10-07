using System.ComponentModel.DataAnnotations;

namespace ProdutosApp.Services.Models
{
    /// <summary>
    /// Modelo de dados para a requisição do serviço de edição de produtos
    /// </summary>
    public class ProdutosPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto.")]
        public Guid? Id { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(250, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a descrição do produto.")]
        public string? Descricao { get; set; }

        [Range(0, 999999, ErrorMessage = "Por favor, informe um valor entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Range(0, 9999, ErrorMessage = "Por favor, informe um valor entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }
    }
}
