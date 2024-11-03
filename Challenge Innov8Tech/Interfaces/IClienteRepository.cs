using Challenge_Innov8Tech.Entities;

namespace Challenge_Innov8Tech.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<ClienteEntity> GetAll();
            ClienteEntity GetById(int id);
        ClienteEntity Insert(ClienteEntity cliente);
        ClienteEntity Update(ClienteEntity cliente);

        ClienteEntity Teste(int id, ClienteEntity cliente);
        void Delete(int id);
    }
}
