using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Model;
using MinimalApi.Services;  

namespace MinimalApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class VooController : ControllerBase
    {
        private readonly AirlineDbContext _context;
        private readonly IServiceVoo _serviceVoo;  

       
        public VooController(AirlineDbContext context, IServiceVoo serviceVoo)
        {
            _context = context;
            _serviceVoo = serviceVoo;  
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetFlights(string origem, string destino, DateTime dataembarque, DateTime? dataretorno)
        {
            var voos = await _context.Voos
                .Where(f => f.Origem == origem && f.Destino == destino && f.DataEmbarque >= dataembarque && (!dataretorno.HasValue || f.DataRetorno <= dataretorno))
                .ToListAsync();

            return Ok(voos);
        }

        [HttpGet("relatorio-ocupacao-semanal")]
        public async Task<ActionResult<IEnumerable<RelatorioOcupacao>>> GetRelatorioOcupacaoSemanal()
        {
            var relatorio = await _serviceVoo.GetRelatorioOcupacaoSemanalAsync();
            return Ok(relatorio);
        }
    }
}
