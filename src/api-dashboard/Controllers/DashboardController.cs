using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WAProject.Data;
using WAProject.Domain;
using WAProjetct.API.Helpers;

namespace WAProjetct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly WAProjectContext _context;
        private readonly IPedidoRepository _pedidoRepository;

        public DashboardController(WAProjectContext context, IPedidoRepository pedidoRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _pedidoRepository = pedidoRepository;

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        // GET api/[controller]/encomendas[?registrosPorPagina=3&indice=10]
        [HttpGet]
        [Route("encomendas")]
        [ProducesResponseType(typeof(IEnumerable<Encomenda>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PedidosAsync([FromQuery] int registrosPorPagina = 10, [FromQuery] int indice = 0)
        {
            var pedidos = await _context.Encomendas
                                    .Include(s => s.Equipe)
                                    .Include(s => s.Pedido)
                                    .Skip(registrosPorPagina * indice)
                                    .Take(registrosPorPagina)
                                    .ToListAsync();

            return Ok(pedidos);
        }
    }
}
