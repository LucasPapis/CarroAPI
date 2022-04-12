using AutoMapper;
using ProCarros.Application.Dtos;
using ProCarros.Domain;

namespace ProCarros.Application.Helpers
{
    public class ProCarrosProfile : Profile
    {
        public ProCarrosProfile()
        {
            CreateMap<Fabricante, FabricanteDto>().ReverseMap();
            CreateMap<Carro, CarroDto>().ReverseMap();
        }
    }
}