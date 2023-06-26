using ApiCliente.Dto;
using ApiCliente.Entity;

namespace ApiCliente.Repository
{
    public interface IClienteRepository
    {
        public Task<ICollection<ClienteDto>> GetCliente();
        public Task<ClienteDto> CreateCliente(ClienteDto cliente);
        public Task<ClienteDto> UpdateCliente(ClienteDto cliente);
        public Task<bool> DeleteCliente(int id);
    }
}
