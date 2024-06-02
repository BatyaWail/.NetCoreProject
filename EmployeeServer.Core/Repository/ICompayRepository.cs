using EmployeeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Core.Repository
{
    public interface ICompanyRepository
    {
        Task<Company> GetCopmanyByNameAndPaswword(string name, string paswword);
        Task<List<Company>> GetListAsync();
        Task<Company> AddCompanyAsync(Company company);

    }
}
