using AutoMapper;
using BackOffice.Model;
using BackOffice.ViewModel;

namespace BackOffice.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<EmployeeViewModel,Employee>().ReverseMap();
        }
    }
}