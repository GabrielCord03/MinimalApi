using Microsoft.AspNetCore.Mvc;
using MinimalApi.Model;
using MinimalApi.Services;

namespace MinimalApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassageiroController : ControllerBase
    {
        private readonly IServicePassageiro _servicePassageiro;

        public PassageiroController(IServicePassageiro servicePassageiro)
        {
            _servicePassageiro = servicePassageiro;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<Passageiro>> CadastrarPassageiro(string cpf, [FromBody] Passageiro passageiro)
        {
            var existente = await _servicePassageiro.GetPassageiroByCpfAsync(cpf);
            if (existente != null)
            {
                return BadRequest("Passageiro já cadastrado.");
            }

            await _servicePassageiro.AddPassageiroAsync(passageiro);
            return CreatedAtAction(nameof(CadastrarPassageiro), new { cpf = passageiro.CPF }, passageiro);
        }
    }
}
