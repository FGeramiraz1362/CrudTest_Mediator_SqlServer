using AutoMapper;
using Mc2.CrudTest.Presentation.Server.Models;
using Shared.Dtos;


namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>().MaxDepth(1)
            .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.PhoneNumebr.MobileNumber))
            .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.PhoneNumebr.CountryCode));

            CreateMap<Role, RoleDto>().MaxDepth(1);
            CreateMap<User, UserDto>().MaxDepth(1);
        }

    }
}
