using Challenge_Innov8Tech.Infrastructure;
using Challenge_Innov8Tech.Interfaces;
using Challenge_Innov8Tech.Entities;
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
            return _context.Clientes;
        }
        public ClienteEntity GetById(int id)
        {
            return _context.Clientes.Find(id);
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
        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

    }

    }

