using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassaIngressos_WebAPI.Controllers;
using PassaIngressos_WebAPI.Database;
using PassaIngressos_WebAPI.Dto;
using PassaIngressos_WebAPI.Entity;
using System.Linq.Expressions;
using Moq;

namespace PassaIngressos_WebAPI.Tests
{
    public class EventosTests
    {
        private readonly Mock<DbPassaIngressos> _mockContext;
        private readonly Mock<DbSet<Evento>> _mockSet;
        private readonly EventosController _controller;

        public EventosTests()
        {
            _mockContext = new Mock<DbPassaIngressos>();
            _mockSet = new Mock<DbSet<Evento>>();
            _controller = new EventosController(_mockContext.Object);
        }

        [Fact]
        public async Task CriarEvento_RetornaOk_QuandoEventoCriadoComSucesso()
        {
            // Arrange
            var eventoDto = new EventoDto
            {
                NomeEvento = "Show de Rock",
                LocalEvento = "Estádio",
                DataHoraEvento = DateTime.Now.AddMonths(1)
            };

            _mockContext.Setup(m => m.Eventos).Returns(_mockSet.Object);

            // Act
            var result = await _controller.CriarEvento(eventoDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);

            _mockSet.Verify(m => m.Add(It.IsAny<Evento>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task EditarEvento_RetornaOk_QuandoEventoEditadoComSucesso()
        {
            // Arrange
            var eventoExistente = new Evento
            {
                IdEvento = 1,
                NomeEvento = "Show de Rock",
                LocalEvento = "Estádio",
                DataHoraEvento = DateTime.Now.AddMonths(1)
            };

            var eventoAtualizado = new EventoDto
            {
                NomeEvento = "Show de Pop",
                LocalEvento = "Arena",
                DataHoraEvento = DateTime.Now.AddMonths(2)
            };

            _mockContext.Setup(m => m.Eventos.FindAsync(1))
                        .ReturnsAsync(eventoExistente);

            // Act
            var result = await _controller.EditarEvento(1, eventoAtualizado);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
            Assert.Equal(eventoAtualizado.NomeEvento, eventoExistente.NomeEvento);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ExcluirEvento_RetornaOk_QuandoEventoExcluidoComSucesso()
        {
            // Arrange
            var eventoExistente = new Evento
            {
                IdEvento = 1,
                NomeEvento = "Show de Rock"
            };

            _mockContext.Setup(m => m.Eventos.FindAsync(1))
                        .ReturnsAsync(eventoExistente);

            // Act
            var result = await _controller.ExcluirEvento(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            _mockSet.Verify(m => m.Remove(It.IsAny<Evento>()), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ListarEventos_RetornaOk_QuandoExistemEventos()
        {
            // Arrange
            var eventos = new List<Evento>
        {
            new Evento { IdEvento = 1, NomeEvento = "Show de Rock" },
            new Evento { IdEvento = 2, NomeEvento = "Show de Jazz" }
        }.AsQueryable();

            _mockSet.As<IQueryable<Evento>>().Setup(m => m.Provider).Returns(eventos.Provider);
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.Expression).Returns(eventos.Expression);
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.ElementType).Returns(eventos.ElementType);
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.GetEnumerator()).Returns(eventos.GetEnumerator());

            _mockContext.Setup(m => m.Eventos).Returns(_mockSet.Object);

            // Act
            var result = await _controller.ListarEventos();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var listaEventos = Assert.IsType<List<Evento>>(okResult.Value);
            Assert.Equal(2, listaEventos.Count);
        }

        [Fact]
        public async Task PesquisarEvento_RetornaOk_QuandoEventoEncontrado()
        {
            // Arrange
            var evento = new Evento
            {
                IdEvento = 1,
                NomeEvento = "Show de Rock",
                LocalEvento = "Estádio"
            };

            var eventos = new List<Evento> { evento }.AsQueryable();

            // Configura o mock do DbSet para se comportar como IQueryable
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.Provider).Returns(eventos.Provider);
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.Expression).Returns(eventos.Expression);
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.ElementType).Returns(eventos.ElementType);
            _mockSet.As<IQueryable<Evento>>().Setup(m => m.GetEnumerator()).Returns(eventos.GetEnumerator());

            _mockContext.Setup(m => m.Eventos).Returns(_mockSet.Object);

            // Act
            var result = await _controller.PesquisarEvento(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var eventoRetornado = Assert.IsType<Evento>(okResult.Value);
            Assert.Equal(1, eventoRetornado.IdEvento);
        }
    }
}