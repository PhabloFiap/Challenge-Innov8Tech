using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;



namespace Challenge_Innov8Tech.Services
{
    public class ClienteApplicationService : IClienteAplicationService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteApplicationService(IClienteRepository clienteRepository, IClienteService clienteService)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public ClienteEntity GetById(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public IEnumerable<ClienteEntity> GetAll()
        {
            return _clienteRepository.GetAll();
        }
 
        public ClienteEntity Insert(ClienteEntity cliente)
        {
            return _clienteRepository.Insert(cliente);
        }
        public ClienteEntity Update(ClienteEntity cliente)
        {
            return _clienteRepository.Update(cliente);
        }
        public void Delete(int id)
        {
            _clienteRepository.Delete(id);
        }

        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var endereco = await _clienteService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return endereco;

            return null;
        }
    }
}
