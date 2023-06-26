using ApiCliente.DbContexts;
using ApiCliente.Dto;
using ApiCliente.Entity;
using ApiCliente.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.Services
{
    public class FlotaServices : IFlotaRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;

        public FlotaServices(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FlotaDto> CreateFlota(FlotaDto flota)
        {
            var flotaDb = _mapper.Map<Flota>(flota);
            dbContext.flota.Add(flotaDb);
            await dbContext.SaveChangesAsync();
            return _mapper.Map<FlotaDto>(flotaDb);
        }

        public async Task<FlotaDto> UpdateFlota(FlotaDto flota)
        {
            var flotaDb = _mapper.Map<Flota>(flota);
            dbContext.flota.Update(flotaDb);
            await dbContext.SaveChangesAsync();
            return flota;
        }

        public async Task<bool> DeleteFlota(int id)
        {
            var flota = await dbContext.flota.FirstOrDefaultAsync(c => c.id == id);
            if (flota == null)
            {
                return false;
            }
            dbContext.Remove(flota);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<FlotaDto>> GetFlota()
        {
            return _mapper.Map<ICollection<FlotaDto>>(await dbContext.flota.ToListAsync());
           
        }

        
    }
}
