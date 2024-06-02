using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Dtos;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        private readonly IMapper _mapper;
        public CompanyController(
             IMapper mapper, ICompanyService companyService)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var companiesDto = _mapper.Map<List<CopmanyDto>>(await _companyService.GetCompaniesListAsync());

            return Ok(companiesDto);
        }
        // POST api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompanyPostModel value)
        {
            Company company = _mapper.Map<Company>(value);
            var x = await _companyService.AddCompanyAsync(_mapper.Map<Company>(value));
            var company3= _mapper.Map<CopmanyDto>(x);
            return Ok(company3);
        }
    }
}
