using ApiCliente.Dto;
using ApiCliente.Entity;
using AutoMapper;

namespace ApiCliente.Mapper
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<Flota, FlotaDto>().ReverseMap();
        }
    }
}
