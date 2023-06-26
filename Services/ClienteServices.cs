using ApiCliente.DbContexts;
using ApiCliente.Dto;
using ApiCliente.Entity;
using ApiCliente.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.Services
{
    public class ClienteServices : IClienteRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;

        public ClienteServices(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<ClienteDto>> GetCliente()
        {
            return _mapper.Map<ICollection<ClienteDto>>(await dbContext.cliente.ToListAsync());
        }

        public async Task<ClienteDto> CreateCliente(ClienteDto cliente)
        {
            var clienteDb = _mapper.Map<Cliente>(cliente);
            await dbContext.cliente.AddAsync(clienteDb);
            await dbContext.SaveChangesAsync();
            return _mapper.Map<ClienteDto>(clienteDb);

        }

        public async Task<ClienteDto> UpdateCliente(ClienteDto cliente)
        {
            var clienteDb = _mapper.Map<Cliente>(cliente);
            dbContext.cliente.Update(clienteDb);
            await dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await dbContext.cliente.FirstOrDefaultAsync(c => c.id == id);
            if (cliente == null)
            {
                return false;
            }
            dbContext.Remove(cliente);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
