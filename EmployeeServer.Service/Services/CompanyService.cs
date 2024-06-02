using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using EmployeeServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServer.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> AddCompanyAsync(Company company)
        {
            return await _companyRepository.AddCompanyAsync(company);
        }

        public async Task<List<Company>> GetCompaniesListAsync()
        {
            return await _companyRepository.GetListAsync();
        }

        public async Task<Company> GetCompanyByNameAndPaswword(string name, string paswword)
        {
            return await _companyRepository.GetCopmanyByNameAndPaswword(name, paswword);
        }
    }
}
