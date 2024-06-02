using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByNameAndPaswword(string name, string paswword);
        Task<List<Company>> GetCompaniesListAsync();
        Task<Company> AddCompanyAsync(Company company);

    }
}
