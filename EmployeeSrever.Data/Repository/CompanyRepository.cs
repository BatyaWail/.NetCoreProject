using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSrever.Data.Repository
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly DataContext _dataContext;
        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       

        public async Task<Company> GetCopmanyByNameAndPaswword(string name, string paswword)
        {
            return await _dataContext.Companies.FirstOrDefaultAsync(u => u.Name == name && u.Password == paswword);
        }

        public async Task<List<Company>> GetListAsync()
        {
            return await _dataContext.Companies.ToListAsync();
        }
        public async Task<Company> AddCompanyAsync(Company company)
        {
            _dataContext.Companies.Add(company);
            await _dataContext.SaveChangesAsync();
            return company;
        }
    }
}
