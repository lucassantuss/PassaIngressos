using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassaIngressos_WebAPI.Database;
using PassaIngressos_WebAPI.Dto;

namespace PassaIngressos_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly DbPassaIngressos _dbPassaIngressos;

        public EventosController(DbPassaIngressos _context)
        {
            _dbPassaIngressos = _context;
        }

        // Método para criar evento
        [HttpPost("CriarEvento")]
        public async Task<IActionResult> CriarEvento([FromBody] Evento evento)
        {
            _dbPassaIngressos.Eventos.Add(evento);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok(evento);
        }

        // Método para excluir evento
        [HttpDelete("ExcluirEvento/{id}")]
        public async Task<IActionResult> ExcluirEvento(int id)
        {
            var evento = await _dbPassaIngressos.Eventos.FindAsync(id);

            if (evento == null)
                return NotFound("Evento não encontrado.");

            _dbPassaIngressos.Eventos.Remove(evento);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok("Evento excluído com sucesso.");
        }

        // Método para criar ingresso associado ao evento
        [HttpPost("CriarIngresso")]
        public async Task<IActionResult> CriarIngresso([FromBody] Ingresso ingresso)
        {
            var evento = await _dbPassaIngressos.Eventos.FindAsync(ingresso.IdEvento);

            if (evento == null)
                return NotFound("Evento não encontrado.");

            _dbPassaIngressos.Ingressos.Add(ingresso);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok(ingresso);
        }

        // Método para excluir ingresso
        [HttpDelete("ExcluirIngresso/{id}")]
        public async Task<IActionResult> ExcluirIngresso(int id)
        {
            var ingresso = await _dbPassaIngressos.Ingressos.FindAsync(id);

            if (ingresso == null)
                return NotFound("Ingresso não encontrado.");

            _dbPassaIngressos.Ingressos.Remove(ingresso);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok("Ingresso excluído com sucesso.");
        }

        // Método para buscar eventos disponíveis
        [HttpGet("BuscarEventosDisponiveis")]
        public async Task<IActionResult> BuscarEventosDisponiveis()
        {
            var eventos = await _dbPassaIngressos.Eventos.ToListAsync();

            return Ok(eventos);
        }

        // Método para buscar ingressos por evento
        [HttpGet("BuscarIngressosPorEvento/{idEvento}")]
        public async Task<IActionResult> BuscarIngressosPorEvento(int idEvento)
        {
            var ingressos = await _dbPassaIngressos.Ingressos.Where(i => i.IdEvento == idEvento).ToListAsync();

            if (ingressos == null || !ingressos.Any())
                return NotFound("Nenhum ingresso encontrado para o evento.");

            return Ok(ingressos);
        }
    }
}