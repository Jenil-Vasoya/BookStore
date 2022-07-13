using Bookstore.models.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("Role")]
    public class RoleController : ControllerBase
    {
        RoleRepository _roleRepository = new RoleRepository();

        [Route("GetRoles")]
        [HttpGet]

        public IActionResult GetRoles()
        {
            return Ok(_roleRepository.GetRoles());
        }

        [Route("Id")]
        [HttpGet]
        public IActionResult GetRole(int id)
        {
            var role = _roleRepository.GetRole(id);
            RoleModel rolemodel = new RoleModel(role);
            return Ok(rolemodel);
        }
    }
}
