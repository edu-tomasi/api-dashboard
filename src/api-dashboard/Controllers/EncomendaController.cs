using api_dashboard.Applcation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAProject.Core.DomainObjects;
using WAProject.Data;
using WAProject.Domain;

namespace api_dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncomendaController : ControllerBase
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IEncomendaService _encomendaService;
        private readonly WAProjectContext _context;

        public EncomendaController(IEquipeRepository equipeRepository, IEncomendaService encomendaService, WAProjectContext context)
        {
            _equipeRepository = equipeRepository;
            _encomendaService = encomendaService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //SeedPedido();

            var result = _encomendaService.ObterTodasEncomendasPorDataDeCriacao();

            return new JsonResult(result.GetAwaiter().GetResult());

            //return Ok();
        }

        private void SeedPedido()
        {
            var equ = new Equipe
            {
                Descricao = "Descricao Teste",
                Nome = "Nome Teste",
                PlacaVeiculoUtilizado = "XPT0123"
            };

            var ped = new Pedido
            {
                DataDeCriacao = DateTime.Now,
                PedidoItens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        Descricao = "Descricao Teste",
                        Nome = "Nome Teste",
                        ProdutoId = Guid.NewGuid(),
                        Valor = 100
                    }
                },
                Endereco = new Endereco
                {
                    Bairro = "Bairro Teste",
                    CEP = "00000000",
                    Cidade = "Cidade Teste",
                    Logradouro = "Logradouro Teste",
                    Numero = 123
                }
            };

            var enc = new Encomenda()
            {
                Codigo = "XPTO1234",
                Equipe = equ,
                EquipeId = equ.Id,
                Pedido = ped
                //PedidoId = ped.Id
            };

            //ped.Encomenda = enc;
            ped.EncomendaId = enc.Id;

            _context.Encomendas.Add(enc);

            _context.Commit().GetAwaiter().GetResult();
            
        }
    }
}
