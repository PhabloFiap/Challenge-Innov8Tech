using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace namespace_Challenge_Innov8Tech.Tests
{
    public  class ClienteRepositoryTests
    {



        [Fact]
        public void Insert_ShouldReturnClienteEntity_WhenClienteIsInserted()
        {
            // Arrange
            var mockRepository = new Mock<IClienteRepository>();
            var cliente = new ClienteEntity
            {
                Id = 1,
                Nome = "Cliente Teste",
                Cpf = "12345678901",
                Email = "cliente@teste.com",
                Telefone = "(11) 91234-5678"
            };

            // Configura o mock para retornar o mesmo cliente ao chamar Insert
            mockRepository.Setup(repo => repo.Insert(It.IsAny<ClienteEntity>())).Returns(cliente);

            // Act
            var result = mockRepository.Object.Insert(cliente);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cliente.Id, result.Id);
            Assert.Equal(cliente.Nome, result.Nome);
            Assert.Equal(cliente.Cpf, result.Cpf);
            Assert.Equal(cliente.Email, result.Email);
            Assert.Equal(cliente.Telefone, result.Telefone);
        }
    }

}

