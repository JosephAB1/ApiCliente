using ApiCliente.DbContexts;
using ApiCliente.Dto;
using ApiCliente.Entity;
using ApiCliente.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ApiCliente.Services
{
    public class MarcaServices : IMarcaRepository
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper _mapper;


        public MarcaServices(AppDbContext dbContext, IMapper _mapper)
        {
            this.dbContext = dbContext;
            this._mapper = _mapper;
        }

        public async Task<MarcaDto> CreateMarca(MarcaDto marca)
        {
            var marcaDb = _mapper.Map<Marca>(marca);
            dbContext.marca.Add(marcaDb);
            await dbContext.SaveChangesAsync();
            return _mapper.Map<MarcaDto>(marcaDb);
        }

        public async Task<MarcaDto> UpdateMarca(MarcaDto marca)
        {
            var marcaDb = _mapper.Map<Marca>(marca);
            dbContext.marca.Update(marcaDb);
            await dbContext.SaveChangesAsync();
            return marca;
        }
        public async Task<bool> DeleteMarca(int id)
        {
            var marca = await dbContext.marca.FirstOrDefaultAsync(c => c.id == id);
            if (marca == null)
            {
                return false;
            }
            dbContext.Remove(marca);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<MarcaDto>> GetMarca()
        {
            return _mapper.Map<ICollection<MarcaDto>>(await dbContext.marca.ToListAsync());
        }

        public async Task<MarcaDto> GetMarcayById(int id)
        {
            var mr = _mapper.Map<MarcaDto>(
                await dbContext.marca.Where(m => m.id == id)
                 .FirstOrDefaultAsync());
            return mr;
        }
    }
}
