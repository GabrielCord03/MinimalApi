using Microsoft.AspNetCore.Mvc;
using MinimalApi.Data;
using MinimalApi.Model;

namespace MinimalApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly AirlineDbContext _context;

        public ReservaController(AirlineDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReservation(Reserva reserva)
        {
            var voo = await _context.Voos.FindAsync(reserva.IdVoo);
            if (voo == null || voo.AssentosDisponiveis <= 0)
            {
                return BadRequest("No available seats.");
            }

            voo.AssentosDisponiveis--;
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reserva.Id }, reserva);
        }
    }
}
