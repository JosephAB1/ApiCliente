using ApiCliente.Dto;
using ApiCliente.Entity;

namespace ApiCliente.Repository
{
    public interface IMarcaRepository
    {
       
        public Task<ICollection<MarcaDto>> GetMarca();

        Task<MarcaDto> GetMarcayById(int id);
        public Task<MarcaDto> CreateMarca(MarcaDto marca);
        public Task<MarcaDto> UpdateMarca(MarcaDto marca);
        public Task<bool> DeleteMarca(int id);
    }
}
