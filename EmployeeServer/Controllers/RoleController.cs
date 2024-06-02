using AutoMapper;
using EmployeeServer.Api.Model;
using EmployeeServer.Core.Dtos;
using EmployeeServer.Core.Entities;
using EmployeeServer.Core.Services;
using EmployeeServer.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list =await _roleService.GetRolesListAsync();
            var listDto = new List<RoleDto>();
            foreach (var role in list)
            {
                listDto.Add(_mapper.Map<RoleDto>(role));
            }
            return Ok(listDto);
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = _mapper.Map<RoleDto>( await _roleService.GetRoleByIdAsync(id));
            if (item != null)
                return Ok(item);
            return NotFound();
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolePostModel role)
        {
            Role newRole = _mapper.Map<Role>(role);
            return Ok(await _roleService.AddRoleAsync(newRole));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RoleDto role)
        {
            Role newRole = _mapper.Map<Role>(role);
            var role2 = await _roleService.GetRoleByIdAsync(id);
            if (role2 == null)
                return NotFound();
            //if (_roleService.GetRoleById(id, newRole)!=null)

            return Ok(await _roleService.UpdateRoleAsync(id, newRole));
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _roleService.RemoveRoleAsync(id);
            return Ok();
        }
    }
}
