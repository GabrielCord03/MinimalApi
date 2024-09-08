using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VooController : ControllerBase
    {
        private readonly AirlineDbContext _context;

        public VooController(AirlineDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetFlights(string origem, string destino, DateTime dataembarque, DateTime? dataretorno)
        {
            var voos = await _context.Voos
                .Where(f => f.Origem == origem && f.Destino == destino && f.DataEmbarque >= dataembarque && (!dataretorno.HasValue || f.DataRetorno <= dataretorno))
                .ToListAsync();

            return Ok(voos);
        }
    }
}
