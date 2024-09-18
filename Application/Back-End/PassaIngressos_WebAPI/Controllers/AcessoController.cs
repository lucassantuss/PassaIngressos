using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassaIngressos_WebAPI.Database;
using PassaIngressos_WebAPI.Dto;

namespace PassaIngressos_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly DbPassaIngressos _dbPassaIngressos;

        public AcessoController(DbPassaIngressos _context)
        {
            _dbPassaIngressos = _context;
        }

        // Método para criar usuário
        [HttpPost("CriarUsuario")]
        public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
        {
            var pessoa = await _dbPassaIngressos.Pessoas.FindAsync(usuario.IdPessoa);

            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha); // Criptografa a senha

            _dbPassaIngressos.Usuarios.Add(usuario);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok(usuario);
        }

        // Método para redefinir senha
        [HttpPut("RedefinirSenha/{id}")]
        public async Task<IActionResult> RedefinirSenha(int id, [FromBody] string novaSenha)
        {
            var usuario = await _dbPassaIngressos.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(novaSenha);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok("Senha redefinida com sucesso.");
        }

        // Método para validar usuário e realizar o login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var usuario = await _dbPassaIngressos.Usuarios
                                .SingleOrDefaultAsync(u => u.Login == loginDto.Login &&
                                                           u.Senha == loginDto.Senha);

            if (usuario == null)
                return Unauthorized("Login ou senha inválidos.");

            return Ok("Login realizado com sucesso.");
        }

        // Método para pesquisar usuário
        [HttpGet("PesquisarUsuario/{login}")]
        public async Task<IActionResult> PesquisarUsuario(string login)
        {
            var usuario = await _dbPassaIngressos.Usuarios.Include(u => u.IdPessoa)
                                                 .SingleOrDefaultAsync(u => u.Login == login);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        // Método para excluir conta
        [HttpDelete("ExcluirConta/{id}")]
        public async Task<IActionResult> ExcluirConta(int id)
        {
            var usuario = await _dbPassaIngressos.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            _dbPassaIngressos.Usuarios.Remove(usuario);
            await _dbPassaIngressos.SaveChangesAsync();

            return Ok("Conta excluída com sucesso.");
        }

        // Método para pesquisar perfis
        [HttpGet("Perfis")]
        public async Task<IActionResult> PesquisarPerfis()
        {
            var listaPerfis = await _dbPassaIngressos.Perfis.ToListAsync();                                   

            if (listaPerfis == null)
                return NotFound("Não foi encontrado nenhum perfil.");

            return Ok(listaPerfis);
        }
    }
}