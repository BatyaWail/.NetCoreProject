using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Dtos;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Repository;
using EmployeeServer.Core.Services;
using EmployeeServer.Service.Services;
//using EmployeeSrever.Data.Migrations;
using EmployeeSrever.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRoleService _roleService;
        private readonly IEmployeeRoleSrervice _employeeRoleSrervice;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService,IRoleService roleService
            ,IMapper mapper, IEmployeeRoleSrervice employeeRoleSrervice)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _employeeRoleSrervice = employeeRoleSrervice;
            _mapper = mapper;
        }
        //[Authorize]

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _employeeService.GetEmployeesListAsync();
            var listDto = new List<EmployeeDto>();
            foreach (var employee in list)
            {
                //Console.WriteLine(employee.EmployeeRoles[1].EmployeeId);
                listDto.Add(_mapper.Map<EmployeeDto>(employee));
            }
            if(listDto!=null)
                return Ok(listDto);
            return NotFound();
        }
        //public ActionResult Get()
        //{
        //    var list = _employeeService.GetEmployeesList();
        //    return Ok(list);
        //}

        // GET api/<EmployeeController>/5
        [HttpGet("{identity}")]
        public async Task<ActionResult> Get(string identity)
        {
            var employee=await _employeeService.GetEmployeeByIdAsync(identity);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }
        //[Authorize]
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EmployeePostModel employeePostModel)
        {
            var employee = _mapper.Map<Employee>(employeePostModel);          
            employee.Status = true;
            return Ok(_mapper.Map<EmployeeDto>( await _employeeService.AddEmployeeAsync(employee)));
            //return Ok(_employeeService.AddEmployee(employee2));
        }

        
        [HttpPut("{identity}")]
        public async Task<ActionResult> Put(string identity, [FromBody] EmployeePostModel employeePostModel)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(identity);
            if (employee == null)
            {
                return NotFound();
            }
            //_mapper.Map(employeePostModel, employee);
            var employee2 = _mapper.Map<Employee>(employeePostModel);

            // Update the employee in the database
            var employee3 = await _employeeService.UpdateEmployeeAsync(identity, employee2);
            // Return Ok response
            var employee4 = _mapper.Map<EmployeeDto>(employee3);
            return Ok(employee4);
        }

        //[HttpPut("{id}")]
        //public ActionResult Put(string id, [FromBody] EmployeePostModel employeePostModel)
        //{
        //    var employee = _employeeService.GetEmployeeById(id);

        //    // If employee doesn't exist, return NotFound
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    // Update scalar properties of the employee
        //    employee.FirstName = employeePostModel.FirstName;
        //    employee.LastName = employeePostModel.LastName;
        //    employee.Identity = employeePostModel.Identity;
        //    employee.StartDate = employeePostModel.StartDate;
        //    employee.DateOfBirth = employeePostModel.DateOfBirth;
        //    employee.Gender = employeePostModel.Gender;
        //    employee.Status = employeePostModel.Status;

        //    // Update employee roles
        //    foreach (var employeeRole in employeePostModel.EmployeeRoles)
        //    {
        //        var roleId = employeeRole.Role.Id; // Assuming the role ID is provided in the DTO

        //        var role = _roleService.GetRoleById(roleId);

        //        if (role == null)
        //        {
        //            // Role doesn't exist, return BadRequest or handle the scenario accordingly
        //            return BadRequest($"Role with ID {roleId} not found.");
        //        }

        //        // Check if the employee already has this role
        //        var existingEmployeeRole = employee.EmployeeRoles.FirstOrDefault(er => er.RoleId == roleId);
        //        if (existingEmployeeRole != null)
        //        {
        //            // Update the entry date of the existing role
        //            existingEmployeeRole.EntryDate = employeeRole.EntryDate;
        //        }
        //        else
        //        {
        //            // Create a new employee role
        //            var newEmployeeRole = new EmployeeRole
        //            {
        //                EmployeeId = employee.Id,
        //                Employee = employee,
        //                RoleId = roleId,
        //                Role = role,
        //                EntryDate = employeeRole.EntryDate
        //            };
        //            employee.EmployeeRoles.Add(newEmployeeRole);
        //        }
        //    }

        //    // Update the employee in the database
        //    _employeeService.UpdateEmployee(id, employee);

        //    // Return Ok response
        //    return Ok();
        //}



        // DELETE api/<EmployeeController>/5
        [HttpDelete("{identity}")]
        public async Task<ActionResult> Delete(string identity)
        {
            var employee= await _employeeService.GetEmployeeByIdAsync(identity);
            if (employee == null)
            {
                return NotFound();
            }
            await _employeeService.RemoveEmployeeAsync(identity);
            return NoContent();
        }
    }
}
