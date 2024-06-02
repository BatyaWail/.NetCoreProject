using AutoMapper;
using EmployeeServer.Core.Dtos;
using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<EmployeeRole, EmployeeRoleDto>().ReverseMap();
            CreateMap<Company, CopmanyDto>().ReverseMap();
        }

    }
}
