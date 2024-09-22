using Microsoft.AspNetCore.Mvc;
using PassaIngressos_WebAPI.Controllers;
using PassaIngressos_WebAPI.Database;
using PassaIngressos_WebAPI.Dto;
using PassaIngressos_WebAPI.Entity;
using Moq;

namespace PassaIngressos_WebAPI.Tests
{
    public class AcessoTests
    {
        private readonly Mock<DbPassaIngressos> _mockContext;
        private readonly AcessoController _controller;

        public AcessoTests()
        {
            _mockContext = new Mock<DbPassaIngressos>();
            _controller = new AcessoController(_mockContext.Object);
        }

        //[Fact]
        //public async Task Login_RetornaOk_QuandoAsCredenciaisForemValidas()
        //{
        //    // Arrange
        //    var loginDto = new LoginDto { Login = "user1", Senha = "password" };
        //    var usuario = new Usuario { Login = "user1", Senha = BCrypt.Net.BCrypt.HashPassword("password") };
        //    _mockContext.Setup(c => c.Usuarios.SingleOrDefaultAsync(It.IsAny<Expression<Func<Usuario, bool>>>()))
        //                .ReturnsAsync(usuario);

        //    // Act
        //    var result = await _controller.Login(loginDto);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    Assert.Equal("Login realizado com sucesso.", okResult.Value);
        //}

        //[Fact]
        //public async Task Login_RetornaNaoAutorizado_QuandoAsCredenciaisForemInvalidas()
        //{
        //    // Arrange
        //    var loginDto = new LoginDto { Login = "user1", Senha = "password" };
        //    var usuario = new Usuario { Login = "user1", Senha = BCrypt.Net.BCrypt.HashPassword("password") };

        //    // Mock do retorno do usuário ao buscar pelo login
        //    _mockContext.Setup(c => c.Usuarios
        //        .SingleOrDefaultAsync(It.Is<Expression<Func<Usuario, bool>>>(expr =>
        //            expr.Body.ToString().Contains("user1")))
        //    ).ReturnsAsync(usuario);

        //    // Act
        //    var result = await _controller.Login(loginDto);

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var okResult = result as OkObjectResult;
        //    Assert.Equal("Login realizado com sucesso.", okResult.Value);
        //}

        [Fact]
        public async Task CriarUsuario_RetornaOk_QuandoUsuarioForCriado()
        {
            // Arrange
            var usuarioDto = new UsuarioDto { Login = "newuser", Senha = "password", NomePessoa = "New User" };

            // Act
            var result = await _controller.CriarUsuario(usuarioDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var createdUsuario = Assert.IsAssignableFrom<Usuario>(okResult.Value);
            Assert.Equal("newuser", createdUsuario.Login);
        }

        [Fact]
        public async Task RemoverUsuario_RetornaOk_QuandoUsuarioForRemovido()
        {
            // Arrange
            var usuario = new Usuario { IdUsuario = 1, Login = "userToDelete" };
            _mockContext.Setup(c => c.Usuarios.FindAsync(1)).ReturnsAsync(usuario);

            // Act
            var result = await _controller.ExcluirConta(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Conta excluída com sucesso.", okResult.Value);
        }

        [Fact]
        public async Task RemoverUsuario_RetornaNaoEncontrado_QuandoUsuarioNaoExistir()
        {
            // Arrange
            _mockContext.Setup(c => c.Usuarios.FindAsync(1)).ReturnsAsync((Usuario)null);

            // Act
            var result = await _controller.ExcluirConta(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Equal("Usuário não encontrado.", notFoundResult.Value);
        }

        [Fact]
        public async Task CriarPerfil_RetornaOk_QuandoPerfilForCriado()
        {
            // Arrange
            var perfilDto = new PerfilDto { NomePerfil = "NewProfile", DescricaoPerfil = "Description" };

            // Act
            var result = await _controller.CriarPerfil(perfilDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var createdPerfil = Assert.IsAssignableFrom<Perfil>(okResult.Value);
            Assert.Equal("NewProfile", createdPerfil.NomePerfil);
        }

        [Fact]
        public async Task RemoverPerfil_RetornaOk_QuandoPerfilForRemovido()
        {
            // Arrange
            var perfil = new Perfil { IdPerfil = 1, NomePerfil = "ProfileToDelete" };
            _mockContext.Setup(c => c.Perfis.FindAsync(1)).ReturnsAsync(perfil);

            // Act
            var result = await _controller.RemoverPerfil(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Perfil removido com sucesso.", okResult.Value);
        }

        [Fact]
        public async Task RemoverPerfil_RetornaNaoEncontrado_QuandoPerfilNaoExistir()
        {
            // Arrange
            _mockContext.Setup(c => c.Perfis.FindAsync(1)).ReturnsAsync((Perfil)null);

            // Act
            var result = await _controller.RemoverPerfil(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.Equal("Perfil não encontrado.", notFoundResult.Value);
        }
    }
}