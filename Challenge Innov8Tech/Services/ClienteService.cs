using Challenge_Innov8Tech.Entities;
using Challenge_Innov8Tech.Interfaces;
using RestSharp;

namespace Challenge_Innov8Tech.Services
{
    public class ClienteService : IClienteService
    {
        private readonly RestClient _restClient;

        public ClienteService()
        {
            _restClient = new RestClient("https://viacep.com.br/ws/");

        }
        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var request = new RestRequest($"{cep}/json/", Method.Get);
            var response = await _restClient.ExecuteAsync<Endereco>(request);

            if (!response.IsSuccessful || response.Data == null)
                return null;

            return response.Data;
        }


    }
}
