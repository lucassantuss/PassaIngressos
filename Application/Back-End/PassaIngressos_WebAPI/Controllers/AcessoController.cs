using Microsoft.AspNetCore.Mvc;
using PassaIngressos_WebAPI.Database;

namespace PassaIngressos_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly DbPassaIngressos _dbPassaIngressos;

        public AcessoController(DbPassaIngressos _context)
        {
            _dbPassaIngressos = _context;
        }

        // Método para criar usuário
        [HttpPost(Name = "PostNovoUsuario")]
        public void PostNovoUsuario()
        {

        }

        // Método para redefinir senha
        [HttpPut(Name = "PutRedefinirSenha")]
        public void PutRedefinirSenha()
        {

        }

        // Método para validar usuário e realizar o login
        [HttpPost(Name = "PostLogin")]
        public void PostLogin()
        {

        }

        // Método para pesquisar usuário
        [HttpGet(Name = "GetUsuario")]
        public void GetUsuario()
        {

        }

        // Método para excluir conta
        [HttpDelete(Name = "DeleteUsuario")]
        public void DeleteUsuario(int? idUsuario)
        {

        }
    }
}