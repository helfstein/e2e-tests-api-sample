#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocApiSample.Domain;

namespace PocApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PedidoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), 200)]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), 204)]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), 500)]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pedido), 200)]
        [ProducesResponseType(typeof(Pedido), 404)]
        [ProducesResponseType(typeof(Pedido), 500)]
        public async Task<ActionResult<Pedido>> GetPedido(Guid id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Pedido), 200)]
        [ProducesResponseType(typeof(Pedido), 304)]
        [ProducesResponseType(typeof(Pedido), 404)]
        [ProducesResponseType(typeof(Pedido), 500)]
        public async Task<IActionResult> PutPedido(Guid id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 201)]
        [ProducesResponseType(typeof(Guid), 400)]
        [ProducesResponseType(typeof(Guid), 500)]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            pedido.CreatedAt = DateTime.Now;
            pedido.Id = Guid.NewGuid();
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return Created("Post",pedido.Id);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Guid), 404)]
        [ProducesResponseType(typeof(Guid), 500)]
        public async Task<IActionResult> DeletePedido(Guid id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(Guid id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
