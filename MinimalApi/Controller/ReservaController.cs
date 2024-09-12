using Microsoft.AspNetCore.Mvc;
using MinimalApi.Model;
using MinimalApi.Services;

namespace MinimalApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IServiceReserva _serviceReserva;
        private readonly IServiceVoo _serviceVoo;
        private readonly IServicePassageiro _servicePassageiro;

        public ReservaController(IServiceReserva serviceReserva, IServiceVoo serviceVoo, IServicePassageiro servicePassageiro)
        {
            _serviceReserva = serviceReserva;
            _serviceVoo = serviceVoo;
            _servicePassageiro = servicePassageiro;
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> CreateReserva(Reserva reserva)
        {
            var voo = await _serviceVoo.GetVooByIdAsync(reserva.IdVoo);
            if (voo == null || voo.AssentosDisponiveis < 1)
            {
                return BadRequest("No available seats.");
            }

            
            voo.AssentosDisponiveis--;
            await _serviceVoo.UpdateVooAsync(voo);

            
            var passageiro = await _servicePassageiro.GetPassageiroByCpfAsync(reserva.Passageiros.CPF);
            if (passageiro == null)
            {
                await _servicePassageiro.AddPassageiroAsync(reserva.Passageiros);
            }

            
            await _serviceReserva.AddReservaAsync(reserva);

            return CreatedAtAction(nameof(GetReservaById), new { id = reserva.Id }, reserva);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReservaById(int id)
        {
            var reserva = await _serviceReserva.GetReservaByIdAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarReserva(int id)
        {
            var reserva = await _serviceReserva.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            var voo = await _serviceVoo.GetVooByIdAsync(reserva.IdVoo);
            if (voo != null)
            {
                voo.AssentosDisponiveis++;
                await _serviceVoo.UpdateVooAsync(voo);
            }

            await _serviceReserva.DeleteReservaAsync(id);
            return NoContent();
        }
       
        [HttpPost("{id}/checkin")]
        public async Task<IActionResult> CheckIn(int id)
        {
            try
            {
                await _serviceReserva.CheckInAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("relatorio-vendas-mensal")]
        public async Task<ActionResult<IEnumerable<RelatorioVendas>>> GetRelatorioVendasMensal()
        {
            var relatorio = await _serviceReserva.GetRelatorioVendasMensalAsync();
            return Ok(relatorio);
        }
    }
}
