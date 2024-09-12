using Microsoft.AspNetCore.Mvc;
using PassaIngressos_WebAPI.Database;

namespace PassaIngressos_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly DbPassaIngressos _dbPassaIngressos;
        
        public EventosController(DbPassaIngressos _context)
        {
            _dbPassaIngressos = _context;
        }
        
        // Método para criar evento

        // Método para excluir evento

        // Método para criar ingresso associado ao evento

        // Método para excluir ingresso

        // Método para buscar eventos disponíveis

        // Método para buscar ingressos por evento
    }
}