
using Bookstore;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Repository;
using Bookstore.models.Models;
using Bookstore.models.ViewModels;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserConroller : ControllerBase
    {
        UserRepository _userRepository = new UserRepository();


        [Route("GetUsers")]
        [HttpGet]

        public IActionResult GetUsers()
        {
            return Ok(_userRepository.GetUsers());
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel model)
        {
            User user = _userRepository.Login(model);
            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _userRepository.Register(model);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateUsers(UserModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Password = model.Password,
                RoleId = model.RoleId,
            };

            var response = _userRepository.UpdateUsers(user);
            UserModel userModel = new UserModel(response);

            return Ok(userModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteUsers(int id)
        {
            var response = _userRepository.DeleteUsers(id);
            return Ok(response);
        }
    }
}
 