using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces;
using ProdutosApp.Services.Models;

namespace ProdutosApp.Services.Controllers
{
    [Authorize(Roles = "USER")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        //atributos
        private readonly IProdutoDomainService? _produtoDomainService;
        private readonly IMapper? _mapper;

        //construtor para inicializar o atributo
        public ProdutosController(IProdutoDomainService? produtoDomainService, IMapper? mapper)
        {
            _produtoDomainService = produtoDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Serviço para cadastro de produtos.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutosGetModel), 201)]
        public IActionResult Post([FromBody] ProdutosPostModel model)
        {
            try
            {
                var produto = _mapper?.Map<Produto>(model);
                _produtoDomainService?.Adicionar(produto);

                var response = _mapper?.Map<ProdutosGetModel>(produto);
                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço para edição de produtos.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put([FromBody] ProdutosPutModel model)
        {
            try
            {
                var produto = _mapper?.Map<Produto>(model);
                _produtoDomainService?.Alterar(produto);

                var response = _mapper?.Map<ProdutosGetModel>(produto);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço para exclusão de produtos.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoDomainService?.ObterPorId(id);
                _produtoDomainService?.Excluir(id);

                var response = _mapper?.Map<ProdutosGetModel>(produto);
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço para consulta de produtos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var produtos = _produtoDomainService?.ObterTodos();

                var response = _mapper?.Map<List<ProdutosGetModel>>(produtos);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço para consulta de 1 produto através do ID (código identificador).
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var produto = _produtoDomainService?.ObterPorId(id);

                if (produto == null)
                    return NoContent();

                var response = _mapper?.Map<ProdutosGetModel>(produto);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}


