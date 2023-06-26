using ApiCliente.Dto;
using ApiCliente.Entity;

namespace ApiCliente.Repository
{
    public interface IFlotaRepository
    {
        public Task<ICollection<FlotaDto>> GetFlota();
        public Task<FlotaDto> CreateFlota(FlotaDto flota);
        public Task<FlotaDto> UpdateFlota(FlotaDto flota);
        public Task<bool> DeleteFlota(int id);
    }
}
