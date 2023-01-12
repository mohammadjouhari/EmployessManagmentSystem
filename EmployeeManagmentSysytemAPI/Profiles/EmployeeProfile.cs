using AutoMapper;

namespace EmployeeManagmentSysytemAPI.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entities.Employee, DTO.Employee>();
            CreateMap<DTO.Employee, Entities.Employee>();
        }
    }
}
