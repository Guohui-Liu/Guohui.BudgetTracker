using Guohui.BudgetTracker.ApplicationCore.Models.Request;
using Guohui.BudgetTracker.ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guohui.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {          
            _incomeService = incomeService;
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateIncome([FromBody] IncomeRequestModel incomeRequest)
        {
            var response = await _incomeService.AddIncome(incomeRequest);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteIncome(int id)
        {
            await _incomeService.DeleteIncome(id);
            return Ok();
        }

        [HttpGet("User/{userId:int}")]
        public async Task<ActionResult> ListUserIncomesAsync(int userId)
        {
            var userIncomes = await _incomeService.ListAllIncomesByUser(userId);
            return Ok(userIncomes);
        }
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> UpdateIncome([FromBody] IncomeRequestModel incomeRequest, int Id)
        {
           var response = await _incomeService.UpdateIncome(incomeRequest, Id);
            return Ok(response);
        }

        [HttpGet("incomes")]
        public async Task<ActionResult> ListAllIncomesAsync()
        {
            var userIncomes = await _incomeService.ListAllIncomes();
            return Ok(userIncomes);
        }

    }
}
