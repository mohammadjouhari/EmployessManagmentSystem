using AutoMapper;
namespace EmployeeManagmentSysytemAPI.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DTO.Department, Entities.Department>();
        }
    }
}


