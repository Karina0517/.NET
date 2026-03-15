using AutoMapper;
using UniversidadITM.Domain.Dtos;
using UniversidadITM.Domain.Entities;

namespace UniversidadITM.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Profesor, ProfesorDto>();
            CreateMap<ProfesorCreateDto, Profesor>();
        }
    }
}
