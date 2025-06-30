using AutoMapper;
using CaseItau.API.ViewModels;
using CaseItau.Domain.DTO;

namespace CaseItau.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ParametroIdFundoDTO, ParametroIdFundoViewModel>().ReverseMap();
            CreateMap<ParametroFundoDTO, ParametroFundoViewModel>().ReverseMap();
            CreateMap<ParametroPatrimonioFundoDTO, ParametroPatrimonioFundoViewModel>().ReverseMap();
        }
    }
}
