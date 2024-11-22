using GlobalSolution.Models;
using GlobalSolution.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumoController : ControllerBase
    {
        private readonly ConsumoService _consumoService;

        public ConsumoController(ConsumoService consumoService)
        {
            _consumoService = consumoService;
        }
        [HttpGet("health")]
        public ActionResult<string> HealthCheck()
        {
            try
            {
                return Ok("Service is running");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao verificar o status do serviço", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Consumo>>> GetConsumo()
        {
            try
            {
                var consumos = _consumoService.Get();
                if (consumos == null || consumos.Count == 0)
                {
                    return NotFound(new { message = "Nenhum consumo encontrado." });
                }
                return Ok(consumos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao consultar dados do consumo", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Consumo>> PostConsumo(Consumo consumo)
        {
            try
            {
                var newConsumo = _consumoService.PostConsumo(consumo);
                return CreatedAtAction(nameof(GetConsumo), new { id = newConsumo.Id }, newConsumo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao salvar novo consumo", error = ex.Message });
            }
        }
    }
}
