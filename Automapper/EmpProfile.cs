using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using efcore.DTOs;
using efcore.Models;

namespace efcore.Automapper
{
    public class EmpProfile: Profile
    {
        public EmpProfile()
        {
            CreateMap<Employee, EmpLoginDTO>().ReverseMap();
            CreateMap<Employee, EmpDetailsDTO>().ForMember(d => d.DeptName, o => o.MapFrom(s => s.department.Name));
            CreateMap<Employee, EmpRegisterDTO>().ReverseMap();
        }
    }
}