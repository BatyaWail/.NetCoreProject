using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Entities;

namespace EmployeeServer.Api.mapping
{
    public class PostModelsMapping : Profile
    {
        public PostModelsMapping()
        {

            CreateMap<EmployeePostModel, Employee>();


            CreateMap<EmployeeRolePostModel, EmployeeRole>();


            CreateMap<RolePostModel, Role>(); // Simple mapping for Role
            CreateMap<LoginModel, Company>();
            CreateMap<CompanyPostModel, Company>();

        }

    }
}
