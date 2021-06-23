using Guohui.BudgetTracker.ApplicationCore.Models.Request;
using Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService/*, IExpenditureService expenditureService, IIncomeService incomeService*/)
        {
            _userService = userService;
            //_expendituresService = expenditureService;
            //_incomeService = incomeService;
        }
       
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }


        [HttpGet("detail/{id:int}")]
        public async Task<ActionResult> GetUserDetailById(int id)
        {
            var user = await _userService.GetUserDetailById(id);
            return Ok(user);
        }

        [HttpGet("")]
        public async Task<ActionResult> ListAllUsers()
        {
            var user = await _userService.ListAllUsers();
            return Ok(user);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUser([FromBody] UserUpdateRequestModel userUpdateRequest, int id)
        {
            var user =await _userService.UpdateUser(userUpdateRequest,id);
            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> RegisterUserAsync(UserRegisterRequestModel user)
        {
            var createdUser = await _userService.RegisterUser(user);
            return Ok();
        }



    }
}
