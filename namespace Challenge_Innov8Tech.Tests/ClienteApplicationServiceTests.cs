using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;
using Challenge_Innov8Tech.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespace_Challenge_Innov8Tech.Tests
{

    public class ClienteApplicationServiceTests
    {
        private readonly Mock<IClienteService> _clienteServiceMock;
        private readonly Mock<IClienteRepository> _repositoryMock;
        private readonly ClienteApplicationService _clienteService;


        public ClienteApplicationServiceTests()
        {
            _repositoryMock = new Mock<IClienteRepository>();
            _clienteServiceMock = new Mock<IClienteService>();

            _clienteService = new ClienteApplicationService(_repositoryMock.Object, _clienteServiceMock.Object);
        }


        [Fact]
        public void GetCliente_ReturnsCliente_WhenClienteExists()
        {
            // Arrange
            var clienteId = 1;
            var expectedCliente = new ClienteEntity { Id = clienteId, Nome = "Cliente Teste" };

            // Configura o mock para retornar um cliente específico quando GetClienteById é chamado com o ID fornecido
            _repositoryMock.Setup(repo => repo.GetById(clienteId))
                .Returns(expectedCliente);

            // Act
            var actualCliente = _clienteService.GetById(clienteId);

            // Assert
            Assert.Equal(expectedCliente, actualCliente);
            _repositoryMock.Verify(repo => repo.GetById(clienteId), Times.Once);
        
    }
        [Fact]
        public void GetCliente_ReturnsNull_WhenClienteDoesNotExist()
        {
            // Arrange
            var clienteId = 1;

            // Configura o mock para retornar null quando GetClienteById é chamado com o ID fornecido
            _repositoryMock.Setup(repo => repo.GetById(clienteId))
                .Returns((ClienteEntity)null);

            // Act
            var actualCliente = _clienteService.GetById(clienteId);

            // Assert
            Assert.Null(actualCliente);
            _repositoryMock.Verify(repo => repo.GetById(clienteId), Times.Once);
        }




    }
}
