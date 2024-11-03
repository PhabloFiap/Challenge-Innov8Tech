using Challenge_Innov8Tech.Infrastructure;
using Challenge_Innov8Tech.Interfaces;
using Challenge_Innov8Tech.Entities;
using Microsoft.EntityFrameworkCore;
namespace Challenge_Innov8Tech.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationContext _context;

        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ClienteEntity> GetAll()
        {
            return _context.Clientes
                .Include(c => c.Ramo) // Inclui a lista de ramos ao buscar todos os clientes
                .ToList();
        }
        public ClienteEntity GetById(int id)
        {
            return _context.Clientes
                .Include(c => c.Ramo) // Isso garante que o ramo será carregado
                .FirstOrDefault(c => c.Id == id);
        }
        public ClienteEntity Insert(ClienteEntity cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }
        public ClienteEntity Update(ClienteEntity cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return cliente;
        }

        public ClienteEntity Teste (int id, ClienteEntity cliente)
        {
            var clienteEntity = _context.Clientes
                .Include(c => c.Ramo)
                .FirstOrDefault(c => c.Id == id);
            if(clienteEntity is not null)
            {
                clienteEntity.Nome = cliente.Nome;
                clienteEntity.Cpf = cliente.Cpf;
                clienteEntity.Email = cliente.Email;
                clienteEntity.Telefone = cliente.Telefone;
                _context.Update(clienteEntity);
                _context.SaveChanges();
                return clienteEntity;
            }
            return cliente;

        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

    }

    }

