using AutoMapper;
namespace EmployeeManagmentSysytemAPI.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<DTO.Country, Entities.Country>();
        }
    }
}


