using AutoMapper;
using KefalosApi.Dtos;
using KefalosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KefalosApi.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            //mapping between source object and destination object
            //in general this profile is used for mapping
            CreateMap<employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, employee>();
            CreateMap<EmployeeUpdateDto, employee>();
            CreateMap<employee, EmployeeUpdateDto>();
        }
    }
}
